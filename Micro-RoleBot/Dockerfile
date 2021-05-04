#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Micro-RoleBot/Micro-RoleBot.csproj", "Micro-RoleBot/"]
RUN dotnet restore "Micro-RoleBot/Micro-RoleBot.csproj"
COPY . .
WORKDIR "/src/Micro-RoleBot"
RUN dotnet build "Micro-RoleBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Micro-RoleBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Micro-RoleBot.dll"]