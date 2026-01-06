namespace OficinaCardozo.Application.DTOs;

/// <summary>
/// DTO para Ordem de Serviço com dados completos
/// </summary>
public class OrdemServicoDto
{
    /// <summary>
    /// ID da ordem de serviço
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Data de solicitaçÍo/recebimento
    /// </summary>
    public DateTime DataSolicitacao { get; set; }

    /// <summary>
    /// ID do veÍ­culo
    /// </summary>
    public int IdVeiculo { get; set; }

    /// <summary>
    /// ID do status atual
    /// </summary>
    public int IdStatus { get; set; }

    /// <summary>
    /// Descrição do status atual
    /// </summary>
    public string? StatusDescricao { get; set; }

    /// <summary>
    /// ğŸ“… Data em que o serviço foi finalizado
    /// </summary>
    public DateTime? DataFinalizacao { get; set; }

    /// <summary>
    /// ğŸš— Data em que o veÍ­culo foi entregue ao cliente
    /// </summary>
    public DateTime? DataEntrega { get; set; }

    /// <summary>
    /// â±ï¸ Tempo total de execução calculado (se finalizado)
    /// </summary>
    public TimeSpan? TempoTotalExecucao => DataFinalizacao.HasValue
        ? DataFinalizacao.Value - DataSolicitacao
        : null;

    /// <summary>
    /// ğŸ•’ Tempo total até entrega (se entregue)
    /// </summary>
    public TimeSpan? TempoTotalEntrega => DataEntrega.HasValue
        ? DataEntrega.Value - DataSolicitacao
        : null;

    // === DADOS DO VEÍCULO ===
    /// <summary>
    /// Placa do veÍ­culo
    /// </summary>
    public string? VeiculoPlaca { get; set; }

    /// <summary>
    /// Marca e modelo do veÍ­culo
    /// </summary>
    public string? VeiculoMarcaModelo { get; set; }

    /// <summary>
    /// Ano de fabricação do veÍ­culo
    /// </summary>
    public int? VeiculoAnoFabricacao { get; set; }

    /// <summary>
    /// Cor do veÍ­culo
    /// </summary>
    public string? VeiculoCor { get; set; }

    // === DADOS DO CLIENTE ===
    /// <summary>
    /// Nome do cliente
    /// </summary>
    public string? ClienteNome { get; set; }

    /// <summary>
    /// CPF ou CNPJ do cliente
    /// </summary>
    public string? ClienteCpfCnpj { get; set; }

    /// <summary>
    /// E-mail principal do cliente
    /// </summary>
    public string? ClienteEmail { get; set; }

    /// <summary>
    /// Telefone principal do cliente
    /// </summary>
    public string? ClienteTelefone { get; set; }

    // === SERVIÍ‡OS E PEÍ‡AS ===
    /// <summary>
    /// Lista de serviços incluÍ­dos na ordem
    /// </summary>
    public ICollection<OrdemServicoServicoDto> Servicos { get; set; } = new List<OrdemServicoServicoDto>();

    /// <summary>
    /// Lista de peças incluÍ­das na ordem
    /// </summary>
    public ICollection<OrdemServicoPecaDto> Pecas { get; set; } = new List<OrdemServicoPecaDto>();

    // === ORÍ‡AMENTOS ===
    /// <summary>
    /// Lista de orçamentos relacionados Í  ordem
    /// </summary>
    public ICollection<OrcamentoDto> Orcamentos { get; set; } = new List<OrcamentoDto>();

    // === PROPRIEDADES CALCULADAS ===
    /// <summary>
    /// Valor total dos serviços
    /// </summary>
    public decimal ValorTotalServicos => Servicos?.Sum(s => s.ValorAplicado ?? 0) ?? 0;

    /// <summary>
    /// Valor total das peças
    /// </summary>
    public decimal ValorTotalPecas => Pecas?.Sum(p => p.ValorTotal ?? 0) ?? 0;

    /// <summary>
    /// Valor total da ordem de serviço
    /// </summary>
    public decimal ValorTotalOrdem => ValorTotalServicos + ValorTotalPecas;

    /// <summary>
    /// Tempo total estimado de execução (soma dos tempos dos serviços)
    /// </summary>
    public int TempoTotalEstimadoHoras => Servicos?.Sum(s => s.TempoEstimado ?? 0) ?? 0;
}