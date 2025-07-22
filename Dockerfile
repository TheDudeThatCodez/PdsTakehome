# Use official .NET SDK image for build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./src/PdsTakehome/*.csproj ./src/PdsTakehome/
COPY ./tests/PdsTakehome.Tests/*.csproj ./tests/PdsTakehome.Tests/
RUN dotnet restore ./src/PdsTakehome/PdsTakehome.csproj

# Copy everything else and build
COPY . .
WORKDIR /app/src/PdsTakehome
RUN dotnet publish -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PdsTakehome.dll"]
