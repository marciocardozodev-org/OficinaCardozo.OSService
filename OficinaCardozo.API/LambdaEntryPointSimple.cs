using Amazon.Lambda.AspNetCoreServer;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

namespace OficinaCardozo.API;

/// <summary>
/// TESTE: Lambda Entry Point simples sem Init()
/// </summary>
public class LambdaEntryPointSimple : APIGatewayHttpApiV2ProxyFunction
{
    // Deixar completamente vazio - usar comportamento padrão
}
