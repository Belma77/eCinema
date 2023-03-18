FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5239
ENV ASPNETCORE_URLS=http://+:5239

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .

FROM build AS publish
RUN dotnet publish "eCinema.Web.API/eCinema.Web.API/eCinema.Web.API.csproj" -c Release -o /app/publish /p:UseAppHost=false
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["eCinema.Web.API/eCinema.Web.API/Script/script.sql", "/app/Script/"]

ENTRYPOINT ["dotnet", "eCinema.Web.API.dll"]