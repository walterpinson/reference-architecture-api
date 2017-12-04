# Getting Started

## Overview
This repository, `reference-architecture-api`, is a core component of an overal reference architecture that I promote for building secure enterprise and Internet-scale web applications.  The is API repository can be used as a template to build microservices in an efficient and repeatable way.

There is no need to reinvent the wheel.  And many best practices are already baked into this solution.

This example API is built on the .NET Core and is cross platform compatiable.  It can run locally on any platform that can host .NET Core and is specifically implemented to run within Linux-based Docker containers.

## Documentation
You can find further documentation detailing the concepts behind this reference architecture in the [reference-architecture-api Wiki][7].

## Install Dependencies
There are a number of depenedencies that must be installed locally on your development machine in order to get this application to build and run.  The dependencies are detailed below, along with direct links that you can use to download them.

### Git SCM
Install [Git SCM][3] for your given platform.  This will install the git bash command-line tool that has all of the environment variables arleady configured.  There is also an option to install the environment variables for use with the standard Windows command-line or OSX Terminal.

Though they are not required, it may also be useful to install [GitHub for Windows or GitHub for Mac][2].

### .Net Command-Line Interface
You will want to install the [dotnet-cli][1] and associated tools.  The build script used in this repository have a dependency on the .NET command-line tools.

### MongoDB
There are a couple of different options for satisfying the MongoDB requirement.

1. You can [download the MongoDB binaries][4] and install directly onto your local development machine.
1. You can downlaod the official [MongoDB Docker image][6] and run that locally.
1. You can use a hosted docker service, like [mLab][5] or Azure's CosmoDB.

### Docker

## Fork the Repository

## Clone the Fork

## Build / Test
You can manually build and test the API on your local host by running the following commands in a git-bash window, terminal window, or Windows command-line window after switching to the repository root directory.

```bash
dotnet restore
dotnet build
dotnet test
```

## Run


[1]: https://www.microsoft.com/net/learn/get-started/ "Get started with .NET in 10 Minutes"
[2]: https://desktop.github.com/ "GitHub Desktop"
[3]: https://git-scm.com/downloads "Git SCM"
[4]: https://www.mongodb.com/download-center#atlas "MongoDB"
[5]: https://mlab.com "mLab"
[6]: https://hub.docker.com/_/mongo/ "Official Mongo Repository"
[7]: walterpinson/reference-architecture-api/wiki