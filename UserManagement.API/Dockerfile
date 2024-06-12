#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#WORKDIR /app
#EXPOSE 5000
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["RestaurantReservation.Core.Domain/RestaurantReservation.Core.Domain.csproj", "RestaurantReservation.Core.Domain/"]
#COPY ["UserManagement.API/UserManagement.API.csproj", "UserManagement.API/"]
#COPY ["UserManagement.Application/UserManagement.Application.csproj", "UserManagement.Application/"]
#COPY ["UserManagement.Domain/UserManagement.Domain.csproj", "UserManagement.Domain/"]
#COPY ["UserManagement.Infrastructure/UserManagement.Infrastructure.csproj", "UserManagement.Infrastructure/"]
#
#RUN dotnet restore "UserManagement.API/UserManagement.API.csproj"
#COPY . .
#WORKDIR "/src/UserManagement.API"
#RUN dotnet build "UserManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "UserManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "UserManagement.API.dll"]

# Usa la imagen base del SDK de .NET para la construcción de la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Establece el directorio de trabajo en /app
WORKDIR /app

# Copia la solución y los archivos de proyecto al directorio de trabajo
#COPY ../../*.sln .

RUN mkdir UserManagement.API

COPY ../RestaurantReservation.Core.Domain/*.csproj RestaurantReservation.Core.Domain/
COPY ../UserManagement.Application/*.csproj UserManagement.Application/
COPY ../UserManagement.Domain/*.csproj UserManagement.Domain/
COPY ../UserManagement.Infrastructure/*.csproj UserManagement.Infrastructure/
COPY ./UserManagement.API/UserManagement.API.csproj ./UserManagement.API/


# Restaura las dependencias especificadas en los archivos de proyecto
RUN dotnet restore ./UserManagement.API

# Copia todo el contenido restante al directorio de trabajo
COPY . .

# Publica la aplicación en modo Release y la salida se coloca en el directorio 'out'
RUN dotnet publish UserManagement.API/UserManagement.API.csproj -c Release -o out

# Usa la imagen base de runtime de ASP.NET para la ejecución de la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Establece el directorio de trabajo en /app
WORKDIR /app

# Copia los archivos publicados desde la etapa de construcción al directorio de trabajo
COPY --from=build-env /app/out .

# Define el punto de entrada para la aplicación
ENTRYPOINT ["dotnet", "UserManagement.API.dll"]

# Expone el puerto 5000 para acceder a la aplicación
EXPOSE 5000