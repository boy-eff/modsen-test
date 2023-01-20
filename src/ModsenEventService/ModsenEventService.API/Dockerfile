FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ModsenEventService/ModsenEventService.API/ModsenEventService.API.csproj", "ModsenEventService.API/"]
COPY ["ModsenEventService/ModsenEventService.Infrastructure/ModsenEventService.Infrastructure.csproj", "ModsenEventService.Infrastructure/"]
COPY ["ModsenEventService/ModsenEventService.Domain/ModsenEventService.Domain.csproj", "ModsenEventService.Domain/"]
COPY ["ModsenEventService/ModsenEventService.Application/ModsenEventService.Application.csproj", "ModsenEventService.Application/"]
RUN dotnet restore "ModsenEventService.API/ModsenEventService.API.csproj"
COPY ./ModsenEventService .
WORKDIR "/src/ModsenEventService.API"
RUN dotnet build "ModsenEventService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/src/ModsenEventService.API/ModsenEventService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ModsenEventService.API.dll"]
