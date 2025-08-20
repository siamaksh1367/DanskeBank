FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY Project.dev/Project.dev.csproj Project.dev/
COPY Project.dal/Project.dal.csproj Project.dal/
COPY . . 

RUN dotnet restore Project.dev/Project.dev.csproj

RUN dotnet tool install --global dotnet-ef

ENV PATH="$PATH:/root/.dotnet/tools"

ENTRYPOINT ["bash"]
