
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./InvestmentCalculator.API/InvestmentCalculator.API.csproj", "InvestmentCalculator.API/"]
COPY ["./InvestmentCalculator.ApplicationCore/InvestmentCalculator.ApplicationCore.csproj", "src/InvestmentCalculator.ApplicationCore/"]

RUN dotnet restore "./InvestmentCalculator.API/InvestmentCalculator.API.csproj"
COPY . .
WORKDIR "/src/src/InvestmentCalculator.API"
RUN dotnet build "InvestmentCalculator.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InvestmentCalculator.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InvestmentCalculator.API.dll"]