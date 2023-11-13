# Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./FootballApi.csproj" --disable-parallel
RUN dotnet publish "./FootballApi.csproj" -c release -o /app --no-restore

# Serve
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "FootballApi.dll"]