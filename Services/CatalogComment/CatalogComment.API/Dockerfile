#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/CatalogComment/CatalogComment.API/CatalogComment.API.csproj", "Services/CatalogComment/CatalogComment.API/"]
RUN dotnet restore "Services/CatalogComment/CatalogComment.API/CatalogComment.API.csproj"
COPY . .
WORKDIR "/src/Services/CatalogComment/CatalogComment.API"
RUN dotnet build "CatalogComment.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CatalogComment.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CatalogComment.API.dll"]