using System.ComponentModel.DataAnnotations;

namespace OficinaCardozo.Application.DTOs;

public class CancelarOrdemServicoDto
{
    [Required(ErrorMessage = "ID da ordem de serviço é obrigatório")]
    public int IdOrdemServico { get; set; }

    [Required(ErrorMessage = "Motivo do cancelamento é obrigatório")]
    [MaxLength(1000, ErrorMessage = "Motivo não pode exceder 1000 caracteres")]
    public string MotivoCancelamento { get; set; } = string.Empty;

    [MaxLength(500, ErrorMessage = "Observações não podem exceder 500 caracteres")]
    public string? ObservacoesAdicionais { get; set; }

    [Required(ErrorMessage = "IndicaçÍo se veículo foi devolvido é obrigatória")]
    public bool VeiculoDevolvido { get; set; }
}