using System.ComponentModel.DataAnnotations;
using OficinaCardozo.Application.Validation;

namespace OficinaCardozo.Application.DTOs;

public class CreateOrdemServicoDto
{
  
    [Required(ErrorMessage = "CPF/CNPJ do cliente é obrigatório")]
    [StringLength(18, ErrorMessage = "CPF/CNPJ deve ter no máximo 18 caracteres")]
    [CpfCnpjValidation(ErrorMessage = "CPF/CNPJ deve estar em formato válido brasileiro")]
    public string ClienteCpfCnpj { get; set; } = string.Empty;

    [Required(ErrorMessage = "Placa do veículo é obrigatória")]
    [StringLength(8, ErrorMessage = "Placa deve ter no máximo 8 caracteres")]
    [PlacaBrasileiraValidation(ErrorMessage = "Placa deve estar no formato brasileiro válido (ABC1234 ou ABC1D23)")]
    public string VeiculoPlaca { get; set; } = string.Empty;

    [Required(ErrorMessage = "Marca/modelo do veículo é obrigatório")]
    [StringLength(100, ErrorMessage = "Marca/modelo deve ter no máximo 100 caracteres")]
    public string VeiculoMarcaModelo { get; set; } = string.Empty;
   [Range(1900, 2030, ErrorMessage = "Ano deve estar entre 1900 e 2030")]
    public int VeiculoAnoFabricacao { get; set; }

    [StringLength(30, ErrorMessage = "Cor deve ter no máximo 30 caracteres")]
    public string? VeiculoCor { get; set; }

    [StringLength(20, ErrorMessage = "Tipo de combustível deve ter no máximo 20 caracteres")]
    public string? VeiculoTipoCombustivel { get; set; }

    [Required(ErrorMessage = "Pelo menos um serviço deve ser selecionado")]
    [MinLength(1, ErrorMessage = "Pelo menos um serviço deve ser selecionado")]
    public List<int> ServicosIds { get; set; } = new List<int>();

    public List<CreateOrdemServicoPecaDto>? Pecas { get; set; } = new List<CreateOrdemServicoPecaDto>();
}