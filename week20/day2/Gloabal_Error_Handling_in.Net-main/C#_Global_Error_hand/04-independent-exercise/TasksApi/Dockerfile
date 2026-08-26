FROM mcr.microsoft.com/dotnet/sdk:8.0 as Publish
WORKDIR /app
COPY  . .
RUN dotnet publish "TasksApi.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=Publish /app .
CMD [ "dotnet", "TasksApi.dll" ]