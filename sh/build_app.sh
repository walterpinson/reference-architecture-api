#!/bin/bash
dotnet restore
dotnet build
dotnet publish  ~/dev/all/reference-architecture-api/src/Infrastructure.WebApi/Infrastructure.WebApi.csproj -o ~/dev/all/reference-architecture-api/publish