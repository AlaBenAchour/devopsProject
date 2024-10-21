#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# USER app
# WORKDIR /app
# EXPOSE 8080
# EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# ARG BUILD_CONFIGURATION=Release
# WORKDIR /src
WORKDIR /app
# COPY ["./DevopsApi/DevopsApi.csproj", "DevopsApi/"]
COPY DevopsApi.csproj ./
# RUN dotnet restore "./DevopsApi/DevopsApi.csproj"
RUN dotnet restore
COPY . ./
# WORKDIR "/src/DevopsApi"
# RUN dotnet build "./DevopsApi.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet publish -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 80
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "DevopsApi.dll"]
# FROM build AS publish
# ARG BUILD_CONFIGURATION=Release
# RUN dotnet publish "./DevopsApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "DevopsApi.dll"]