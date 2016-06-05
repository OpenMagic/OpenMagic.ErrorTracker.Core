// Update Constants.cs with current version number
//
// NOTE: This script is used instead of an inline script in package.json because Windows & Linux
// get environment differently from the command line but this script will work in both environments.

'use strict';

const replace = require("replace");
const shell = require('shelljs');
const version = process.env.npm_package_version;

replace({
  regex: /public const string Version = \"\d+\.\d+\.\d+\.\d\";/,
  replacement: `public const string Version = \"${version}.0\";`,
  paths: ['source/OpenMagic.ErrorTracker.Core/Constants.cs'],
  recursive: false,
  silent: false,
});

shell.exec(`git add .`);
