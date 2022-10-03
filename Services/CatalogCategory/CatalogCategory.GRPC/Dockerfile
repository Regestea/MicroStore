#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/CatalogCategory/CatalogCategory.GRPC/CatalogCategory.GRPC.csproj", "Services/CatalogCategory/CatalogCategory.GRPC/"]
COPY ["Services/CatalogCategory/CatalogCategory.Application/CatalogCategory.Application.csproj", "Services/CatalogCategory/CatalogCategory.Application/"]
COPY ["Services/CatalogCategory/CatalogCategory.Domain/CatalogCategory.Domain.csproj", "Services/CatalogCategory/CatalogCategory.Domain/"]
COPY ["Services/CatalogCategory/CatalogCategory.Infrastructure/CatalogCategory.Infrastructure.csproj", "Services/CatalogCategory/CatalogCategory.Infrastructure/"]
RUN dotnet restore "Services/CatalogCategory/CatalogCategory.GRPC/CatalogCategory.GRPC.csproj"
COPY . .
WORKDIR "/src/Services/CatalogCategory/CatalogCategory.GRPC"
RUN dotnet build "CatalogCategory.GRPC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CatalogCategory.GRPC.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CatalogCategory.GRPC.dll"]