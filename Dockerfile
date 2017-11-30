FROM microsoft/aspnetcore:latest
WORKDIR /app
COPY ./publish .
ENTRYPOINT ["dotnet", "Infrastructure.WebApi.dll"]