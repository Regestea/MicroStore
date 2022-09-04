#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/AWS/AWS.API/AWS.API.csproj", "Services/AWS/AWS.API/"]
RUN dotnet restore "Services/AWS/AWS.API/AWS.API.csproj"
COPY . .
WORKDIR "/src/Services/AWS/AWS.API"
RUN dotnet build "AWS.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AWS.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AWS.API.dll"]