using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using OficinaCardozo.Application.Settings;
using OficinaCardozo.Application.DTOs;
using System.Text.RegularExpressions;

namespace OficinaCardozo.Application.Services;

public interface IEmailMonitorService
{
    Task ProcessarEmailsAsync();
    Task<ComandoEmailDto?> ExtrairComandoDoEmailAsync(MimeMessage email);
}

public class EmailMonitorService : BackgroundService, IEmailMonitorService
{
    private readonly ConfiguracoesEmail _configEmail;
    private readonly ILogger<EmailMonitorService> _logger;
    private readonly IServiceProvider _serviceProvider;

    public EmailMonitorService(
        IOptions<ConfiguracoesEmail> configEmail,
        ILogger<EmailMonitorService> logger,
        IServiceProvider serviceProvider)
    {
        _configEmail = configEmail.Value;
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("?? Email Monitor Service iniciado");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await ProcessarEmailsAsync();
                await Task.Delay(TimeSpan.FromMinutes(_configEmail.IntervaloVerificacaoMinutos), stoppingToken);
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "? Erro no Email Monitor Service");
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        _logger.LogInformation("?? Email Monitor Service finalizado");
    }

    public async Task ProcessarEmailsAsync()
    {
        using var client = new ImapClient();

        try
        {
            _logger.LogDebug("?? Conectando ao servidor IMAP...");

            await client.ConnectAsync(_configEmail.Host, _configEmail.PortaImap, _configEmail.UsarSsl);
            await client.AuthenticateAsync(_configEmail.Email, _configEmail.Senha);

            var inbox = client.Inbox;
            await inbox.OpenAsync(FolderAccess.ReadWrite);

            var searchQuery = SearchQuery.And(
                SearchQuery.NotSeen,
                SearchQuery.DeliveredAfter(DateTime.Now.AddDays(-7))
            );

            var uids = await inbox.SearchAsync(searchQuery);

            _logger.LogDebug("?? Encontrados {Count} emails não lidos", uids.Count);

            foreach (var uid in uids)
            {
                try
                {
                    var message = await inbox.GetMessageAsync(uid);
                    await ProcessarEmailIndividualAsync(message);

                    await inbox.AddFlagsAsync(uid, MessageFlags.Seen, true);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "? Erro ao processar email individual");
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "? Erro ao conectar/processar emails");
        }
        finally
        {
            if (client.IsConnected)
                await client.DisconnectAsync(true);
        }
    }

    private async Task ProcessarEmailIndividualAsync(MimeMessage email)
    {
        try
        {
            var comando = await ExtrairComandoDoEmailAsync(email);

            if (comando == null)
            {
                _logger.LogDebug("?? Email ignorado (não contém comandos válidos): {Subject}", email.Subject);
                return;
            }

            _logger.LogInformation("? Processando comando: OS #{OrdemId} -> {Status}",
                comando.OrdemServicoId, comando.NovoStatus);

            using var scope = _serviceProvider.CreateScope();
            var statusService = scope.ServiceProvider.GetRequiredService<IOrdemServicoStatusService>();

            await statusService.AtualizarStatusViaEmailAsync(comando);

            _logger.LogInformation("? Status atualizado com sucesso: OS #{OrdemId}", comando.OrdemServicoId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "? Erro ao processar comando do email: {Subject}", email.Subject);
        }
    }

    public async Task<ComandoEmailDto?> ExtrairComandoDoEmailAsync(MimeMessage email)
    {
        var assunto = email.Subject?.ToUpper() ?? "";
        var corpo = email.TextBody ?? email.HtmlBody ?? "";
        var remetente = email.From.Mailboxes.FirstOrDefault()?.Address ?? "";

        var padroes = new[]
        {
            @"(?:OS|ORDEM)\s*(\d+)\s*(RECEBIDA|DIAGNOSTICO|ELABORACAO|APROVACAO|EXECUCAO|FINALIZAR|ENTREGAR|CANCELAR|DEVOLVER)",
            @"ATUALIZAR\s*(\d+)\s*PARA\s*(RECEBIDA|DIAGNOSTICO|ELABORACAO|APROVACAO|EXECUCAO|FINALIZADA|ENTREGUE|CANCELADA|DEVOLVIDA)",
            @"STATUS\s*(\d+)\s*:\s*(RECEBIDA|DIAGNOSTICO|ELABORACAO|APROVACAO|EXECUCAO|FINALIZADA|ENTREGUE|CANCELADA|DEVOLVIDA)"
        };

        foreach (var padrao in padroes)
        {
            var match = Regex.Match($"{assunto} {corpo}".ToUpper(), padrao, RegexOptions.IgnoreCase);

            if (match.Success)
            {
                var ordemId = int.Parse(match.Groups[1].Value);
                var statusTexto = match.Groups[2].Value.ToUpper();
                var statusMapeado = MapearStatusTexto(statusTexto);

                if (!string.IsNullOrEmpty(statusMapeado))
                {
                    return new ComandoEmailDto
                    {
                        OrdemServicoId = ordemId,
                        NovoStatus = statusMapeado,
                        RemetenteEmail = remetente,
                        Observacoes = $"Atualização via email - {email.Subject}"
                    };
                }
            }
        }

        return await Task.FromResult<ComandoEmailDto?>(null);
    }

    private static string MapearStatusTexto(string statusTexto)
    {
        return statusTexto.ToUpper() switch
        {
            "RECEBIDA" => OrdemServicoStatusConstants.RECEBIDA,
            "DIAGNOSTICO" => OrdemServicoStatusConstants.EM_DIAGNOSTICO,
            "ELABORACAO" => OrdemServicoStatusConstants.EM_ELABORACAO,
            "APROVACAO" => OrdemServicoStatusConstants.AGUARDANDO_APROVACAO,
            "EXECUCAO" => OrdemServicoStatusConstants.EM_EXECUCAO,
            "FINALIZAR" or "FINALIZADA" => OrdemServicoStatusConstants.FINALIZADA,
            "ENTREGAR" or "ENTREGUE" => OrdemServicoStatusConstants.ENTREGUE,
            "CANCELAR" or "CANCELADA" => OrdemServicoStatusConstants.CANCELADA,
            "DEVOLVER" or "DEVOLVIDA" => OrdemServicoStatusConstants.DEVOLVIDA,
            _ => string.Empty
        };
    }
}