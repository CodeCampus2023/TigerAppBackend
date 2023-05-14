FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY . /app
WORKDIR /app/src/Host/TigerParkBackend.Host.Api
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TigerParkBackend.Host.Api.dll"]

