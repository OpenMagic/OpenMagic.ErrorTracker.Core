// Create NuGet package
//
// NOTE: This script is used instead of an inline script in package.json because Windows & Linux
// get environment differently from the command line but this script will work in both environments.

'use strict';

const version = process.env.npm_package_version;
const nuget = require('npm-nuget');

nuget.exec(`pack ./OpenMagic.ErrorTracker.Core.nuspec -OutputDirectory .\\artifacts -Version ${version} -Symbols`);