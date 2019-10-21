FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ["src/Gym.Notes.API/Gym.Notes.API.csproj", "src/Gym.Notes.API/"]
COPY ["src/Gym.Notes.Infrastructure/Gym.Notes.Infrastructure.csproj", "src/Gym.Notes.Infrastructure/"]

RUN dotnet restore "src/Gym.Notes.API/Gym.Notes.API.csproj"

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Gym.Notes.API.dll"]