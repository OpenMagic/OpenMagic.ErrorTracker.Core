const version = process.env.npm_package_version;
const nuget = require('npm-nuget');

nuget.exec(`pack ./OpenMagic.ErrorTracker.Core.nuspec -OutputDirectory .\\artifacts -Version ${version} -Symbols`); 