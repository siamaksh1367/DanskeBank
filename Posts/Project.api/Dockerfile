FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

COPY ./aspnetapp.pfx /app/aspnetapp.pfx

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=debug
WORKDIR /src
COPY . .

RUN dotnet restore "./Project.api/Project.api.csproj"
WORKDIR "/src/Project.api"
RUN dotnet build "./Project.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=debug
RUN dotnet publish "./Project.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Project.api.dll"]
