# Usa la imagen base del SDK de .NET para la construcción de la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Establece el directorio de trabajo en /app
WORKDIR /app

# Copia la solución y los archivos de proyecto al directorio de trabajo
#COPY ../../*.sln .

RUN mkdir ReservationManagement.API

COPY ../RestaurantReservation.Core.Domain/*.csproj RestaurantReservation.Core.Domain/
COPY ../ReservationManagement.Application/*.csproj ReservationManagement.Application/
COPY ../ReservationManagement.Domain/*.csproj ReservationManagement.Domain/
COPY ../ReservationManagement.Infrastructure/*.csproj ReservationManagement.Infrastructure/
COPY ./ReservationManagement.API/ReservationManagement.API.csproj ./ReservationManagement.API/


# Restaura las dependencias especificadas en los archivos de proyecto
RUN dotnet restore ./ReservationManagement.API

# Copia todo el contenido restante al directorio de trabajo
COPY . .

# Publica la aplicación en modo Release y la salida se coloca en el directorio 'out'
RUN dotnet publish ReservationManagement.API/ReservationManagement.API.csproj -c Release -o out

# Usa la imagen base de runtime de ASP.NET para la ejecución de la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Establece el directorio de trabajo en /app
WORKDIR /app

# Copia los archivos publicados desde la etapa de construcción al directorio de trabajo
COPY --from=build-env /app/out .

# Define el punto de entrada para la aplicación
ENTRYPOINT ["dotnet", "ReservationManagement.API.dll"]

# Expone el puerto 5000 para acceder a la aplicación
EXPOSE 5001