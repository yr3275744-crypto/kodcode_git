
# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o /app/publish .

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KafkaConsumer.dll"]