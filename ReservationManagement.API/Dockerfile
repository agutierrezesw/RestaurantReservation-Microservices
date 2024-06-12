FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ReservationManagement.API/ReservationManagement.API.csproj", "ReservationManagement.API/"]
RUN dotnet restore "ReservationManagement.API/ReservationManagement.API.csproj"
COPY . .
WORKDIR "/src/ReservationManagement.API"
RUN dotnet build "ReservationManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ReservationManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReservationManagement.API.dll"]
