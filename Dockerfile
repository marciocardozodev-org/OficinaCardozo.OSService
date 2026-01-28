
# ===================================================================
# Dockerfile - OficinaCardozo.OSService (.NET 8) - Web/Kubernetes
# OTIMIZADO PARA CACHE
# ===================================================================

# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Variáveis para melhorar diagnóstico
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
ENV NUGET_XMLDOC_MODE=skip

# CACHE LAYER 1: Copiar apenas arquivos de projeto (muda raramente)
COPY ["API/OficinaCardozo.OSService.API.csproj", "API/"]
COPY ["Application/OficinaCardozo.OSService.Application.csproj", "Application/"]
COPY ["Domain/OficinaCardozo.OSService.Domain.csproj", "Domain/"]
COPY ["Infrastructure/OficinaCardozo.OSService.Infrastructure.csproj", "Infrastructure/"]

# CACHE LAYER 2: Restore (só refaz se .csproj mudar)
RUN dotnet restore "API/OficinaCardozo.OSService.API.csproj" --verbosity minimal

# CACHE LAYER 3: Copiar código fonte (muda com frequência)
COPY . .

# CACHE LAYER 4: Build e Publish (sem --no-restore para evitar NETSDK1064)
WORKDIR "/src"
RUN dotnet publish "API/OficinaCardozo.OSService.API.csproj" \
	-c Release \
	-o /app/publish \
	--verbosity minimal \
	/p:UseAppHost=false

# Stage 2: ASP.NET Runtime (Kestrel)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copiar publicação do build
COPY --from=build /app/publish .

# Configurar variáveis de ambiente para API web
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "OficinaCardozo.OSService.API.dll"]
