using System.ComponentModel.DataAnnotations;

namespace OficinaCardozo.Application.DTOs;

/// <summary>
/// DTO para representar uma peça solicitada na criaçÍo de ordem de serviço
/// </summary>
public class CreateOrdemServicoPecaDto
{
    /// <summary>
    /// ID da peça (deve existir no sistema)
    /// </summary>
    [Required(ErrorMessage = "ID da peça é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "ID da peça deve ser maior que zero")]
    public int IdPeca { get; set; }

    /// <summary>
    /// Quantidade da peça solicitada
    /// </summary>
    [Required(ErrorMessage = "Quantidade é obrigatória")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero")]
    public int Quantidade { get; set; }
}