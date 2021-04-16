#!/bin/bash
dotnet restore
dotnet build
dotnet publish  ~/dev/oss/reference-architecture-api/src/Infrastructure.WebApi/Infrastructure.WebApi.csproj -o ~/dev/oss/reference-architecture-api/publish