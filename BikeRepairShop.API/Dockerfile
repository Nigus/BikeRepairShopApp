FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the csproj file from the current context root (which is BikeRepairShop.API folder)
COPY ["BikeRepairShop.API.csproj", "./"]

RUN dotnet restore "./BikeRepairShop.API.csproj"

# Copy everything else
COPY . .

WORKDIR "/src"
RUN dotnet build "./BikeRepairShop.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BikeRepairShop.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BikeRepairShop.API.dll"]
