FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["robot-application-v1/robot-application-v1.csproj", "robot-application-v1/"]
RUN dotnet restore "robot-application-v1/robot-application-v1.csproj"
COPY . .
WORKDIR "/src/robot-application-v1"
RUN dotnet build "robot-application-v1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "robot-application-v1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 5000
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_VERSION=8.0.1
ENV ASPNET_VERSION=8.0.1
ENV DOTNET_URLS=http://+:5021
ENV ASPNETCORE_URLS=http://+:5031
ENV ASPNETCORE_HTTPS_PORT=https://+:5031
ENV  ASPNETCORE_ENVIRONMENT: Development

ENTRYPOINT ["dotnet", "robot-application-v1.dll"]
