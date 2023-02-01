#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://*:5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./InvestmentCalculator.API/InvestmentCalculator.API.csproj", "InvestmentCalculator.API/"]
COPY ["./InvestmentCalculator.ApplicationCore/InvestmentCalculator.ApplicationCore.csproj", "InvestmentCalculator.ApplicationCore/"]

RUN dotnet restore "./InvestmentCalculator.API/InvestmentCalculator.API.csproj"
COPY . .
RUN dotnet build "./InvestmentCalculator.API/InvestmentCalculator.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./InvestmentCalculator.API/InvestmentCalculator.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InvestmentCalculator.API.dll"]