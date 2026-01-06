using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OficinaCardozo.Application.DTOs;
using OficinaCardozo.Application.Services;

namespace OficinaCardozo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PecasController : ControllerBase
{
    private readonly IPecaService _pecaService;

    public PecasController(IPecaService pecaService)
    {
        _pecaService = pecaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PecaDto>>> GetAll()
    {
        try
        {
            var pecas = await _pecaService.GetAllAsync();
            return Ok(pecas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PecaDto>> GetById(int id)
    {
        try
        {
            var peca = await _pecaService.GetByIdAsync(id);
            if (peca == null)
                return NotFound(new { message = "Peça não encontrada" });

            return Ok(peca);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<PecaDto>> Create([FromBody] CreatePecaDto createDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var peca = await _pecaService.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = peca.Id }, peca);
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

 
    [HttpPut("{id}")]
    public async Task<ActionResult<PecaDto>> Update(int id, [FromBody] UpdatePecaDto updateDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var peca = await _pecaService.UpdateAsync(id, updateDto);
            return Ok(peca);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
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

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _pecaService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }
}