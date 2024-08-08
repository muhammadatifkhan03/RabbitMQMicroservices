#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8082
EXPOSE 8083

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Order-Service-webApi/Order-Service.WebApi.csproj", "Order-Service-webApi/"]
COPY ["Order-Service.Dto/Order-Service.Dto.csproj", "Order-Service.Dto/"]
COPY ["Order-Service.Core/Order-Service.Core.csproj", "Order-Service.Core/"]
COPY ["Order-Service.Infrastructure/Order-Service.Infrastructure.csproj", "Order-Service.Infrastructure/"]
RUN dotnet restore "./Order-Service-webApi/Order-Service.WebApi.csproj"
COPY . .
WORKDIR "/src/Order-Service-webApi"
RUN dotnet build "./Order-Service.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Order-Service.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Order-Service.WebApi.dll"]