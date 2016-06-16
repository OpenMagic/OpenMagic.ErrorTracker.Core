'use strict';

const shell = require('shelljs');
const cmd = `"${__dirname}/../packages/xunit.runner.console/tools/xunit.console.exe"`;
const assemblies = `"${__dirname}/../tests/OpenMagic.ErrorTracker.Core.Specifications/bin/Release/OpenMagic.ErrorTracker.Core.Specifications.dll"`;

shell.exec(`${cmd} ${assemblies}`);
