# NugetXray

NugetXray is a command line tool that analyses your nuget and project references. It contains commands that help you see 
how out of date your packages are, diagnose issues with multiple versions of the same package, and more. 

# Installation

NugetXray itself is a package available from [nuget](https://www.nuget.org/packages/NugetXray/). 

```
PS> nuget install NugetXray
```

```
PS> cd .\NugetXray*\tools
PS> .\NugetXray.exe
```

## Building from source

You can close this repository and create your own package using the build script.

This application is built with [dotnet core](https://www.microsoft.com/net/core) so you will need
to install the appropriate tools for your platform.

```
PS> cd build
PS> .\build.ps1
```

# Commands

## Diff

The diff command lets you see how out of date your packages are. It will read all the package.configs in your solution
and compare them to whats available in the package source. By default it will compare against [nuget.org](http://nuget.org).

```
> .\NugetXray.exe diff -d C:\git\ConveyorBelt\
Scanning https://www.nuget.org/api/v2 for packages.configs.
WindowsAzure.Storage.2.1.0.4                                           | -5.0.0      | 3   configs
Newtonsoft.Json.6.0.8                                                  | -3.0.0      | 4   configs
WindowsAzure.Storage.4.3.0                                             | -3.0.0      | 1   configs
...
```

You can also get more detailed output by using the verbose switch.

```
> .\NugetXray.exe diff -d C:\git\ConveyorBelt\ -v
Scanning https://www.nuget.org/api/v2 for packages.configs.
WindowsAzure.Storage.2.1.0.4 | -5.0.0
  C:\git\ConveyorBelt\src\ConveyorBelt.ConsoleWorker\packages.config
  C:\git\ConveyorBelt\src\ConveyorBelt.Tooling\packages.config
  C:\git\ConveyorBelt\src\ConveyorBelt.Worker\packages.config

Newtonsoft.Json.6.0.8 | -3.0.0
  C:\git\ConveyorBelt\src\ConveyorBelt.ConsoleWorker\packages.config
  C:\git\ConveyorBelt\src\ConveyorBelt.Tooling\packages.config
  C:\git\ConveyorBelt\src\ConveyorBelt.Worker\packages.config
  C:\git\ConveyorBelt\test\ConveyorBelt.Tooling.Test\packages.config

...
```

# Issues and feature requests

Please start raise an [issue](https://github.com/naeemkhedarun/NugetXray/issues) on github for any bugs or 
features you would like to see.