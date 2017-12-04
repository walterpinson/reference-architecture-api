# Getting Started

## Overview
This repository, `reference-architecture-api`, is a core component of an overal reference architecture that I promote for building secure enterprise and Internet-scale web applications.  The is API repository can be used as a template to build microservices in an efficient and repeatable way.

There is no need to reinvent the wheel.  And many best practices are already baked into this solution.

This example API is built on the .NET Core and is cross platform compatiable.  It can run locally on any platform that can host .NET Core and is specifically implemented to run within Linux-based Docker containers.

### Get Up and Running Quickly
In order to quickly get up and running, you'll need to perform the following steps; which are expained in detail in the sections below.

1. Install the dependencies
1. Fork the repository
1. Clone the fork
1. Run the build and test commands
1. Run the application

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
You will need to install Docker on your local development machine.
1. Install [Docker for Windows][9]
2. Install [Docker for Mac][8]

## Fork the Repository
Navigate in your browswer to the reference-architecture-api repository.
https://github.com/walterpinson/reference-architecture-api

Follow the GitHub instructions for [Forking a Repository][10].

## Clone the Fork
Navigate to your fork of the reference-architecture-api repository.  Follow the GitHub instructions for [Cloning a Repository][11].

## Build / Test
You can manually build the API on your local host by running the following commands in a git-bash window, terminal window, or Windows command-line window after switching to the repository root directory.

```bash
dotnet restore
dotnet build
```

If you want to run the unit tests and the integration tests, issue the following command in the repository root directory.

```bash
dotnet test
```

## Run
There are a number of scripts that can be used to expedite each aspect of the manual build process or tie them all together in order to get the application running in a Docker container.

### Build and publish the application
`sh/build_app.sh`

### Build the Docker image
`sh/build_image.sh`

### Run the Docker container
`sh/build_continer.sh`

### Build and run the application
`sh/run.sh`

[1]: https://www.microsoft.com/net/learn/get-started/ "Get started with .NET in 10 Minutes"
[2]: https://desktop.github.com/ "GitHub Desktop"
[3]: https://git-scm.com/downloads "Git SCM"
[4]: https://www.mongodb.com/download-center#atlas "MongoDB"
[5]: https://mlab.com "mLab"
[6]: https://hub.docker.com/_/mongo/ "Official Mongo Repository"
[7]: https://github.com/walterpinson/reference-architecture-api/wiki "reference-architecture-api Wiki"
[8]: https://docs.docker.com/docker-for-mac/install/ "Docker for Mac"
[9]: https://docs.docker.com/docker-for-windows/install/ "Docker for Windows"
[10]: https://help.github.com/articles/fork-a-repo/ "Fork a Repository"
[11]: https://help.github.com/articles/cloning-a-repository/ "Cloning a Repository"