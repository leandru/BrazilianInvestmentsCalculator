#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./src/InvestmentCalculator.API/InvestmentCalculator.API.csproj", "/InvestmentCalculator.API/"]
COPY ["./src/InvestmentCalculator.ApplicationCore/InvestmentCalculator.ApplicationCore.csproj", "/InvestmentCalculator.ApplicationCore/"]

RUN dotnet restore "/InvestmentCalculator.API/InvestmentCalculator.API.csproj"
COPY . .
RUN dotnet build "./src/InvestmentCalculator.API/InvestmentCalculator.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./src/InvestmentCalculator.API/InvestmentCalculator.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InvestmentCalculator.API.dll"]
