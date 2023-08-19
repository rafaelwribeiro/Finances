FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FinancesAPI.csproj", "."]
RUN dotnet restore "./FinancesAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "FinancesAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinancesAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet FinancesAPI.dll