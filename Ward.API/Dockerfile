#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ward.API/Ward.API.csproj", "Ward.API/"]
RUN dotnet restore "Ward.API/Ward.API.csproj"
COPY . .
WORKDIR "/src/Ward.API"
RUN dotnet build "Ward.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ward.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ward.API.dll"]