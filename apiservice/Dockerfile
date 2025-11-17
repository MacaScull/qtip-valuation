FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5066

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["apiservice.api/apiservice.api.csproj", "apiservice.api/"]
COPY ["apiservice.application/apiservice.application.csproj", "apiservice.application/"]
COPY ["apiservice.domain/apiservice.domain.csproj", "apiservice.domain/"]
COPY ["apiservice.infrastructure/apiservice.infrastructure.csproj", "apiservice.infrastructure/"]

RUN dotnet restore "apiservice.api/apiservice.api.csproj"

COPY . .
WORKDIR "/src/apiservice.api"
RUN dotnet build "apiservice.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "apiservice.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "apiservice.api.dll"]
