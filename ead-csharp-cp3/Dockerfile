FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ead-csharp-cp3/ead-csharp-cp3.csproj", "ead-csharp-cp3/"]
RUN dotnet restore "ead-csharp-cp3/ead-csharp-cp3.csproj"
COPY . .
WORKDIR "/src/ead-csharp-cp3"
RUN dotnet build "ead-csharp-cp3.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ead-csharp-cp3.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ead-csharp-cp3.dll"]
