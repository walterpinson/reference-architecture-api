FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY ./publish .
ENTRYPOINT ["dotnet", "Infrastructure.WebApi.dll"]