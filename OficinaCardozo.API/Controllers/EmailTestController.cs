using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OficinaCardozo.Application.Settings;
using OficinaCardozo.Application.Services;

namespace OficinaCardozo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailTestController : ControllerBase
{
    private readonly IEmailMonitorService _emailService;
    private readonly ConfiguracoesEmail _config;
    private readonly ILogger<EmailTestController> _logger;

    public EmailTestController(
        IEmailMonitorService emailService,
        IOptions<ConfiguracoesEmail> config,
        ILogger<EmailTestController> logger)
    {
        _emailService = emailService;
        _config = config.Value;
        _logger = logger;
    }

    [HttpGet("verificar-configuracao")]
    public IActionResult VerificarConfiguracao()
    {
        return Ok(new
        {
            Host = _config.Host,
            Email = _config.Email,
            PortaImap = _config.PortaImap,
            UsarSsl = _config.UsarSsl,
            SenhaConfigurada = !string.IsNullOrEmpty(_config.Senha),
            Intervalo = _config.IntervaloVerificacaoMinutos,
            Status = "Configuração carregada com sucesso",
            Timestamp = DateTime.Now
        });
    }

    [HttpPost("testar-conexao")]
    public async Task<IActionResult> TestarConexao()
    {
        try
        {
            _logger.LogInformation("?? Iniciando teste de conexão de email...");
            await _emailService.ProcessarEmailsAsync();

            return Ok(new
            {
                Sucesso = true,
                Mensagem = "? Conexão com email funcionando!",
                Timestamp = DateTime.Now
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "? Erro no teste de conexão");
            return BadRequest(new
            {
                Sucesso = false,
                Erro = ex.Message,
                Tipo = ex.GetType().Name,
                Timestamp = DateTime.Now
            });
        }
    }

    [HttpGet("status")]
    public IActionResult ObterStatus()
    {
        return Ok(new
        {
            Servidor = "Online",
            Porta = "5107 (HTTP) / 7297 (HTTPS)",
            EmailMonitor = "Ativo",
            Timestamp = DateTime.Now,
            ConfiguracaoEmail = new
            {
                Host = _config.Host,
                Email = _config.Email,
                Intervalo = $"{_config.IntervaloVerificacaoMinutos} minuto(s)"
            }
        });
    }
}