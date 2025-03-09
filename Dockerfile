# Use the official .NET SDK as a build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy the project files and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining files and build the app
COPY . ./
RUN dotnet publish -c Release -o out

# Use ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app
COPY --from=build /app/out ./

EXPOSE 8080
ENTRYPOINT ["dotnet", "50HertzDataAPI.dll"]
