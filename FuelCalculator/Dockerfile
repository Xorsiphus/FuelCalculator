FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FuelCalculator/FuelCalculator.csproj", "FuelCalculator/"]
RUN dotnet restore "FuelCalculator/FuelCalculator.csproj"
COPY . .
WORKDIR "/src/FuelCalculator"
RUN dotnet build "FuelCalculator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FuelCalculator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FuelCalculator.dll"]
