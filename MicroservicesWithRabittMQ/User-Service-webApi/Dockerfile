#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["User-Service-webApi/User-Service.WebApi.csproj", "User-Service-webApi/"]
COPY ["User-Service.Infra/User-Service.Infrastructure.csproj", "User-Service.Infra/"]
COPY ["User-Service.Core/User-Service.Core.csproj", "User-Service.Core/"]
COPY ["User-Service.Dto/User-Service.Dto.csproj", "User-Service.Dto/"]
RUN dotnet restore "./User-Service-webApi/User-Service.WebApi.csproj"
COPY . .
WORKDIR "/src/User-Service-webApi"
RUN dotnet build "./User-Service.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./User-Service.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User-Service.WebApi.dll"]