FROM mcr.microsoft.com/dotnet/sdk:3.1 AS builder-env

WORKDIR /app

COPY ./ ./

# WORKDIR /app/app.infraestructura.api/

RUN dotnet restore

RUN dotnet publish -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:3.1

WORKDIR /app

COPY --from=builder-env /app/out .

ENTRYPOINT ["dotnet", "BackEnd_Proyecto.dll"]