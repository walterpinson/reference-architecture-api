FROM microsoft/aspnetcore:3.1
WORKDIR /app
COPY ./publish .
ENTRYPOINT ["dotnet", "Infrastructure.WebApi.dll"]