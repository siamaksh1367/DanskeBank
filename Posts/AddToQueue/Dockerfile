# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/azure-functions/dotnet-isolated:4-dotnet-isolated9.0 AS base
WORKDIR /home/site/wwwroot
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=debug
WORKDIR /src
COPY ["AddToQueue/AddToQueue.csproj", "AddToQueue/"]
COPY ["Project.core/Project.core.csproj", "Project.core/"]
COPY ["Project.common/Project.common.csproj", "Project.common/"]
COPY ["Project.dal/Project.dal.csproj", "Project.dal/"]
RUN dotnet restore "./AddToQueue/AddToQueue.csproj"
COPY . .
WORKDIR "/src/AddToQueue"
RUN dotnet build "./AddToQueue.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=debug
RUN dotnet publish "./AddToQueue.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /home/site/wwwroot
COPY --from=publish /app/publish .
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true