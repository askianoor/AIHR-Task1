#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Task1.API/Task1.API.csproj", "Task1.API/"]
RUN dotnet restore "Task1.API/Task1.API.csproj"
COPY . .
WORKDIR "/src/Task1.API"
RUN dotnet build "Task1.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Task1.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Task1.API.dll"]