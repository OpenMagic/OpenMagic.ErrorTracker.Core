#### TODO ######

- build.cmd
- watch.cmd
- publish.cmd

## todo

    "compile": "npm-msbuild /property:Configuration=Release /verbosity:minimal",
    "clean": "node ./scripts/clean.js",
    "build": "npm install && npm run clean && npm run compile && npm run package",
    "package": "node ./scripts/package.js",
    "test": "test.cmd"

- publish.cmd
- published.cmd
- Documentation
- Specifications

# OpenMagic.ErrorTracker.Core

Core library for OpenMagic.ErrorTracker projects.

[![timpmurphy MyGet Build Status](https://www.myget.org/BuildSource/Badge/timpmurphy?identifier=798e3d35-0c33-4151-878e-61c34cd498bc)](https://www.myget.org/)

## Contributing

1. [Fork this repository](https://github.com/OpenMagic/OpenMagic.ErrorTracker.Core)
1. Clone your fork: `git clone https://github.com/your-fork`
1. Build & test: `build`
1. Fix configuration until all tests pass.
1. Create a feature branch: `git checkout -b new-feature`
1. Create tests & implement feature. Ensure all tests pass: `build`
1. Commit changes: `git commit -am "Add feature"`
1. Push to the remote branch: `git push origin new-feature`
1. Create a pull request
