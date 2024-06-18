FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ReservationManagement.Consumer/ReservationManagement.Consumer.csproj", "ReservationManagement.Consumer/"]
RUN dotnet restore "ReservationManagement.Consumer/ReservationManagement.Consumer.csproj"
COPY . .
WORKDIR "/src/ReservationManagement.Consumer"
RUN dotnet build "ReservationManagement.Consumer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ReservationManagement.Consumer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReservationManagement.Consumer.dll"]
