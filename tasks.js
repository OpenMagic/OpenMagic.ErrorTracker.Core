'use strict';

const configuration = 'Release';
const config = {
    artifacts: './artifacts',
    configuration: configuration,
    constants: './source/OpenMagic.ErrorTracker.Core/Constants.cs',
    xunit: {
        cmd: `"${__dirname}/packages/xunit.runner.console/tools/xunit.console.exe"`,
        assemblies: `"${__dirname}/tests/OpenMagic.ErrorTracker.Core.Specifications/bin/${configuration}/OpenMagic.ErrorTracker.Core.Specifications.dll"`
    }
};

require('shelljs/make');

const npmPackage = require('./package.json');
const mkdirp = require('mkdirp');
const msbuild = require('npm-msbuild');
const nuget = require('npm-nuget');
const replace = require("replace");
const rimraf = require('rimraf');
const shell = require('shelljs');

target.build = function () {
    runningTask('build');
    target.test();
    target.package();
    completedTask('build');
}

target.clean = function () {
    runningTask('clean');
    rimraf.sync(config.artifacts);
    mkdirp.sync(config.artifacts);
    completedTask('clean');
}

target.compile = function () {
    target.clean();
    runningTask('compile');
    msbuild.exec(`/property:Configuration=${config.configuration} /verbosity:minimal`);
    completedTask('compile');
}

target.package = function () {
    target.test();
    runningTask('package');
    nuget.exec(`pack ./OpenMagic.ErrorTracker.Core.nuspec -OutputDirectory .\\artifacts -Version ${npmPackage.version} -Symbols`);
    completedTask('package');
}

target.publish = function (args) {
    runningTask('publish');

    const newVersion = getNewVersionArguement(args);

    // npm version will:
    //      - Run tests
    //      - Update version number in package.json and Constants.cs
    //      - Stage the version number changes to the Git repositoty
    //      - Create the nuget package
    //       
    // See tasks 'npm_preversion, npm_version, npm_postversion' for more details 
    shell.exec(`npm version ${newVersion}`);

    // Push the latest commits and related tags to remote server
    shell.exec(`git push --follow-tags`);

    completedTask('publish');
}

target.test = function (args) {
    if (args != null && args.includes('skipTests')) {
        console.log('Skipping tests as instructed.');
        return;
    }
    target.compile();
    runningTask('test');
    shell.exec(`${config.xunit.cmd} ${config.xunit.assemblies}`);
    completedTask('test');
}

// This script is called by npm before it runs its version command.
target.npm_preversion = function () {
    target.test();
}

// This script is called by npm after it runs it version command but before it adds the git tag.
target.npm_version = function () {
    // do not call target.npm_preversion as npm will have called it.
    updateAssemblyInfo();
    stageChanges();
}

// This script is called by npm after it runs it version command.
target.npm_postversion = function () {
    // tests are not required because npm_preversion did it and all we did was
    // change the version number.
    target.package();
}

function completedTask(name) {
    console.log();
    console.log(`Successfully completed ${name} task.`);
    console.log();
}

function getNewVersionArguement(args) {
    if (args == null || args.length !== 1) {
        writePublishUsage();
        process.exit(1);
    }
    return args[0];
}

function runningTask(name) {
    console.log(`Starting ${name} task...`);
    console.log();
}

function stageChanges() {
    shell.exec(`git add .`);
}

function updateAssemblyInfo() {
    const version = process.env.npm_package_version;

    replace({
        regex: /public const string Version = \"\d+\.\d+\.\d+\.\d\";/,
        replacement: `public const string Version = \"${version}.0\";`,
        paths: [config.constants],
        recursive: false,
        silent: false,
    });
}

function writePublishUsage() {
    console.log();
    console.log(`Usage: publish <newversion> or run-task publish <newversion> or node tasks publish <newversion>`);
    console.log();
    console.log(`where <newversion> is one of:`);
    console.log(`    major, minor, patch, premajor, preminor, prepatch, prerelease, from-git`);
    console.log();
}
