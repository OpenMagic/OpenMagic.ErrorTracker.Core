// NOTE: This script is used instead of an inline script in package.json because Windows & Linux
// get environment differently from the command line but this script will work in both environments.

'use strict';

const shell = require('shelljs');
const newVersion = getNewVersionArgument();

shell.exec(`npm version ${newVersion}`);

function getNewVersionArgument() {
    const newVersion = process.argv[process.argv.length - 1];
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