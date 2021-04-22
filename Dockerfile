FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /app
ENV DOTNET_USE_POLLING_FILE_WATCHER 1

# Copy csproj and restore as distinct layers
COPY . ./
RUN dotnet restore ./reference-architecture-api.sln

# Copy everything else and build
COPY . ./
RUN dotnet publish ./src/Infrastructure.WebApi/Infrastructure.WebApi.csproj --output /out/ --configuration Release

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /out .

EXPOSE 5000-5001
ENTRYPOINT ["dotnet","Infrastructure.WebApi.dll","run", "--no-restore", "--urls", "https://0.0.0.0:5000"]
