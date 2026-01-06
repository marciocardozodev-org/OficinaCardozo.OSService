using System.ComponentModel.DataAnnotations;

namespace OficinaCardozo.Application.DTOs;

public class OrcamentoDto
{
    public int Id { get; set; }
    public DateTime DataOrcamento { get; set; }
    public int IdOrdemServico { get; set; }
    public int IdStatus { get; set; }
    public string? StatusDescricao { get; set; }

    // Informações resumidas da ordem de serviço
    public string? ClienteNome { get; set; }
    public string? ClienteEmail { get; set; }
    public string? VeiculoPlaca { get; set; }
    public string? VeiculoMarcaModelo { get; set; }

    // Valores do orçamento
    public decimal ValorServicos { get; set; }
    public decimal ValorPecas { get; set; }
    public decimal ValorTotal { get; set; }

    // Detalhes dos serviços e peças
    public ICollection<OrcamentoServicoDto> Servicos { get; set; } = new List<OrcamentoServicoDto>();
    public ICollection<OrcamentoPecaDto> Pecas { get; set; } = new List<OrcamentoPecaDto>();
}

public class EnviarOrcamentoParaAprovacaoDto
{
    [Required(ErrorMessage = "ID do orçamento é obrigatório")]
    public int IdOrcamento { get; set; }

    [MaxLength(500, ErrorMessage = "Observações não podem exceder 500 caracteres")]
    public string? Observacoes { get; set; }
}

public class OrcamentoServicoDto
{
    public string NomeServico { get; set; } = string.Empty;
    public decimal ValorAplicado { get; set; }
    public int TempoEstimado { get; set; }
    public string DescricaoDetalhada { get; set; } = string.Empty;
}

public class OrcamentoPecaDto
{
    public string NomePeca { get; set; } = string.Empty;
    public string CodigoIdentificador { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal ValorTotal { get; set; }
    public string UnidadeMedida { get; set; } = string.Empty;
}

public class AprovarOrcamentoDto
{
    [Required(ErrorMessage = "ID do orçamento é obrigatório")]
    public int IdOrcamento { get; set; }

    [Required(ErrorMessage = "Status de aprovação é obrigatório")]
    public bool Aprovado { get; set; }

    [MaxLength(500, ErrorMessage = "Observações não podem exceder 500 caracteres")]
    public string? Observacoes { get; set; }

    /// <summary>
    /// Quando rejeitado, indica se cliente quer nova proposta (volta para diagnóstico)
    /// ou se desistiu do serviço completamente
    /// </summary>
    public bool SolicitarNovoOrcamento { get; set; } = false;

    /// <summary>
    /// Quando rejeitado e desistiu do serviço, indica se veículo já foi retirado
    /// true = Marca como "Devolvida", false = Marca como "Cancelada" 
    /// </summary>
    public bool VeiculoJaRetirado { get; set; } = false;

    /// <summary>
    /// Motivo da rejeição (quando Aprovado = false)
    /// </summary>
    [MaxLength(1000, ErrorMessage = "Motivo da rejeição não pode exceder 1000 caracteres")]
    public string? MotivoRejeicao { get; set; }
}