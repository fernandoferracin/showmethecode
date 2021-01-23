#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["./Services/CalculaJuros.API/CalculaJuros.API.csproj", "./Services/CalculaJuros.API/"]
COPY ["./Business/DesafioTecnico.Business/DesafioTecnico.Business.csproj", "./Business/DesafioTecnico.Business/"]

RUN dotnet restore "./Services/CalculaJuros.API/CalculaJuros.API.csproj"
COPY . .
WORKDIR "Services/CalculaJuros.API"
RUN dotnet build "CalculaJuros.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculaJuros.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculaJuros.API.dll"]