using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OficinaCardozo.Application.DTOs;
using OficinaCardozo.Application.Interfaces;
using OficinaCardozo.Domain.Exceptions;

namespace OficinaCardozo.API.Controllers.Administrativo;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;
    private readonly ILogger<ClientesController> _logger;

    public ClientesController(IClienteService clienteService, ILogger<ClientesController> logger)
    {
        _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ClienteDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> ObterTodosClientes()
    {
        try
        {
            var clientes = await _clienteService.ObterTodosClientesAsync();
            return Ok(clientes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter todos os clientes");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { message = "Erro interno do servidor" });
        }
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ClienteDto>> ObterClientePorId(int id)
    {
        try
        {
            var cliente = await _clienteService.ObterClientePorIdAsync(id);

            if (cliente == null)
                return NotFound(new { message = "Cliente não encontrado" });

            return Ok(cliente);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "ID inválido fornecido: {Id}", id);
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter cliente por ID: {Id}", id);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { message = "Erro interno do servidor" });
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ClienteDto>> CriarCliente([FromBody] CreateClienteDto createDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cliente = await _clienteService.CriarClienteAsync(createDto);

            return CreatedAtAction(
                nameof(ObterClientePorId),
                new { id = cliente.Id },
                cliente);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Dados inválidos fornecidos para criação de cliente");
            return BadRequest(new { message = ex.Message });
        }
        catch (CpfCnpjJaCadastradoException ex)
        {
            _logger.LogWarning(ex, "CPF/CNPJ já cadastrado: {CpfCnpj}", createDto.CpfCnpj);
            return Conflict(new { message = ex.Message });
        }
        catch (CpfCnpjInvalidoException ex)
        {
            _logger.LogWarning(ex, "CPF/CNPJ inválido: {CpfCnpj}", createDto.CpfCnpj);
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar cliente");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { message = "Erro interno do servidor" });
        }
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ClienteDto>> AtualizarCliente(int id, [FromBody] UpdateClienteDto updateDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cliente = await _clienteService.AtualizarClienteAsync(id, updateDto);
            return Ok(cliente);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Dados inválidos fornecidos para atualização de cliente ID: {Id}", id);
            return BadRequest(new { message = ex.Message });
        }
        catch (ClienteNaoEncontradoException ex)
        {
            _logger.LogWarning(ex, "Cliente não encontrado para atualização ID: {Id}", id);
            return NotFound(new { message = ex.Message });
        }
        catch (CpfCnpjJaCadastradoException ex)
        {
            _logger.LogWarning(ex, "CPF/CNPJ já cadastrado para outro cliente: {CpfCnpj}", updateDto.CpfCnpj);
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar cliente ID: {Id}", id);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { message = "Mensagem: Erro interno do servidor" });
        }
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RemoverCliente(int id)
    {
        try
        {
            await _clienteService.RemoverClienteAsync(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "ID inválido fornecido para remoção: {Id}", id);
            return BadRequest(new { message = ex.Message });
        }
        catch (ClienteNaoEncontradoException ex)
        {
            _logger.LogWarning(ex, "Cliente não encontrado para remoção ID: {Id}", id);
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao remover cliente ID: {Id}", id);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { message = "Erro interno do servidor" });
        }
    }
}