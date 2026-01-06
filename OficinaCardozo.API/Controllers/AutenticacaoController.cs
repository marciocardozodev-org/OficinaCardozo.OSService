using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OficinaCardozo.Application.DTOs;
using OficinaCardozo.Application.Services;
using System.Security.Claims;

namespace OficinaCardozo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutenticacaoController : ControllerBase
{
    private readonly IAutenticacaoService _autenticacaoService;

    public AutenticacaoController(IAutenticacaoService autenticacaoService)
    {
        _autenticacaoService = autenticacaoService;
    }

 
    [HttpPost("login")]
    public async Task<ActionResult<TokenRespostaDto>> Login([FromBody] LoginDto loginDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _autenticacaoService.FazerLoginAsync(loginDto);
            return Ok(resultado);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    [HttpPost("login-cpf")]
    public async Task<ActionResult<TokenRespostaDto>> LoginPorCpf([FromBody] LoginCpfDto loginCpfDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _autenticacaoService.FazerLoginPorCpfAsync(loginCpfDto);
            return Ok(resultado);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    
    [HttpPost("registro")]
    public async Task<ActionResult<UsuarioDto>> Registro([FromBody] CriarUsuarioDto criarUsuarioDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _autenticacaoService.CriarUsuarioAsync(criarUsuarioDto);
            return CreatedAtAction(nameof(ObterPerfil), new { }, resultado);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

   
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetAll()
    {
        try
        {
            var usuarios = await _autenticacaoService.ObterTodosUsuariosAsync();
            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

   
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<UsuarioDto>> GetById(int id)
    {
        try
        {
            var usuario = await _autenticacaoService.ObterUsuarioPorIdAsync(id);
            if (usuario == null)
                return NotFound(new { message = "Usu�rio n�o encontrado" });

            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    [HttpGet("perfil")]
    [Authorize]
    public ActionResult<object> ObterPerfil()
    {
        try
        {
            var idUsuario = User.FindFirst("idUsuario")?.Value;
            var nomeUsuario = User.FindFirst("nomeUsuario")?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            return Ok(new
            {
                idUsuario,
                nomeUsuario,
                email,
                claims = User.Claims.Select(c => new { c.Type, c.Value }),
                mensagem = "Autentica��o JWT funcionando."
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    [HttpPost("validar-token")]
    public async Task<ActionResult<bool>> ValidarToken([FromBody] string token)
    {
        try
        {
            var ehValido = await _autenticacaoService.ValidarTokenAsync(token);
            return Ok(new { ehValido, mensagem = ehValido ? "Token v�lido" : "Token inv�lido" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }
}