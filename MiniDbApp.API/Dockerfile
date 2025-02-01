FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MiniDbApp.API/MiniDbApp.API.csproj", "MiniDbApp.API/"]
COPY ["MiniDbApp.Database/MiniDbApp.Database.csproj", "MiniDbApp.Database/"]
COPY ["MiniDbApp.Models/MiniDbApp.Models.csproj", "MiniDbApp.Models/"]
COPY ["MiniDbApp.Lib/MiniDbApp.Lib.csproj", "MiniDbApp.Lib/"]
RUN dotnet restore "MiniDbApp.API/MiniDbApp.API.csproj"
COPY . .
WORKDIR "/src/MiniDbApp.API"
RUN dotnet build "MiniDbApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MiniDbApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniDbApp.API.dll"]
