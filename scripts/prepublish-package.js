// NOTE: This script is used instead of an inline script in package.json because Windows & Linux
// get environment differently from the command line but this script will work in both environments.

'use strict';

const shell = require('shelljs');
const newVersion = getNewVersionArgument();

shell.exec(`npm version ${newVersion}`);

function getArgvAsJson(argvAsString) {
    try {
        return JSON.parse(argvAsString);
    } catch (error) {
        writeUsage();
        throw new Error(`Cannot parse process.env.npm_config_argv '${argvAsString}'.\n\n${error}`);
    }
}

function getArgvAsString() {
    const argvAsString = process.env.npm_config_argv;

    if (argvAsString == null) {
        writeUsage();
        throw new Error(`process.env.npm_config_argv cannot be null.`);
    }

    return argvAsString;
}

function getOriginalCommandLineArguments(argvAsJson) {
    const originalCommandLineArguments = argvAsJson.original;

    if (originalCommandLineArguments == null) {
        writeUsage();
        throw new Error(`Cannot get original command line arguments from process.env.npm_config_argv '${process.env.npm_config_argv}'.`);
    }

    return originalCommandLineArguments;
}

function getNewVersionArgument() {
    const argvAsString = getArgvAsString();
    const argvAsJson = getArgvAsJson(argvAsString);
    const originalCommandLineArguments = getOriginalCommandLineArguments(argvAsJson);
    const newVersion = originalCommandLineArguments.pop();
    const acceptsNewVersions = ['major', 'minor', 'patch', 'premajor', 'preminor', 'prepatch', 'prerelease', 'from-git'];

    if (!acceptsNewVersions.includes(newVersion)) {
        writeUsage();
        throw new Error(`Invalid newversion '${newVersion}'`);
    }
    
    return newVersion;
}

function writeUsage() {
    console.log();
    console.log(`Usage: package <newversion> or npm run publish-package <newversion> or npm run prepublish-package <newversion>`);
    console.log();
    console.log(`where <newversion> is one of:`);
    console.log(`    major, minor, patch, premajor, preminor, prepatch, prerelease, from-git`);
    console.log();
}