# ===================================================================
# Dockerfile - Oficina Cardozo API (.NET 8) - AWS Lambda
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
COPY ["OficinaCardozo.sln", "./"]
COPY ["OficinaCardozo.API/OficinaCardozo.API.csproj", "OficinaCardozo.API/"]
COPY ["OficinaCardozo.Application/OficinaCardozo.Application.csproj", "OficinaCardozo.Application/"]
COPY ["OficinaCardozo.Domain/OficinaCardozo.Domain.csproj", "OficinaCardozo.Domain/"]
COPY ["OficinaCardozo.Infrastructure/OficinaCardozo.Infrastructure.csproj", "OficinaCardozo.Infrastructure/"]
COPY ["OficinaCardozo.Tests/OficinaCardozo.Tests.csproj", "OficinaCardozo.Tests/"]

# CACHE LAYER 2: Restore (só refaz se .csproj mudar)
RUN dotnet restore "OficinaCardozo.sln" --verbosity minimal

# CACHE LAYER 3: Copiar código fonte (muda com frequência)
COPY . .

# CACHE LAYER 4: Build e Publish (sem --no-restore para evitar NETSDK1064)
WORKDIR "/src"
RUN dotnet publish "OficinaCardozo.API/OficinaCardozo.API.csproj" \
    -c Release \
    -o /app/publish \
    --verbosity minimal \
    /p:UseAppHost=false

# Stage 2: Lambda Runtime
FROM public.ecr.aws/lambda/dotnet:8 AS final

# Copiar publicação do build
COPY --from=build /app/publish ${LAMBDA_TASK_ROOT}

# Configurar variáveis de ambiente para Lambda
ENV ASPNETCORE_ENVIRONMENT=Production

# TESTE: Handler usando classe simples
CMD ["OficinaCardozo.API::OficinaCardozo.API.LambdaEntryPointSimple::FunctionHandlerAsync"]
