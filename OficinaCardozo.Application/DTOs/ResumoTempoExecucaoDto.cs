namespace OficinaCardozo.Application.DTOs;

/// <summary>
/// DTO simplificado para resumo completo de tempos de execução
/// </summary>
public class ResumoTempoExecucaoDto
{
    /// <summary>
    /// Resumo de cada ordem de serviço individual
    /// </summary>
    public List<OrdemServicoResumoDto> OrdensServico { get; set; } = new();

    /// <summary>
    /// EstatÍ­sticas gerais de tempo médio
    /// </summary>
    public EstatisticasGeraisDto EstatisticasGerais { get; set; } = new();

    /// <summary>
    /// Tempo médio por cliente
    /// </summary>
    public List<TempoMedioPorClienteDto> TempoMedioPorCliente { get; set; } = new();
}

/// <summary>
/// Resumo individual de cada ordem de serviço
/// </summary>
public class OrdemServicoResumoDto
{
    public int IdOrdemServico { get; set; }
    public string ClienteNome { get; set; } = string.Empty;
    public string VeiculoPlaca { get; set; } = string.Empty;
    public string VeiculoMarcaModelo { get; set; } = string.Empty;
    public DateTime DataSolicitacao { get; set; }
    public DateTime? DataFinalizacao { get; set; }
    public DateTime? DataEntrega { get; set; }
    public string StatusDescricao { get; set; } = string.Empty;
    public decimal ValorTotal { get; set; }

    /// <summary>
    /// Tempo total até Finalizaçãoo em horas (se finalizada)
    /// </summary>
    public double? TempoFinalizacaoHoras => DataFinalizacao?.Subtract(DataSolicitacao).TotalHours;

    /// <summary>
    /// Tempo total até entrega em horas (se entregue)
    /// </summary>
    public double? TempoEntregaHoras => DataEntrega?.Subtract(DataSolicitacao).TotalHours;

    /// <summary>
    /// Tempo formatado para exibição amigável
    /// </summary>
    public string TempoFormatado => DataEntrega.HasValue
        ? FormatarTempo(TempoEntregaHoras ?? 0)
        : DataFinalizacao.HasValue
        ? $"{FormatarTempo(TempoFinalizacaoHoras ?? 0)} (aguardando entrega)"
        : "Em andamento";

    /// <summary>
    /// Status do tempo de execução com indicadores visuais
    /// </summary>
    public string StatusTempo => DataEntrega.HasValue
        ? $"ConcluÍ­da em {TempoFormatado}"
        : DataFinalizacao.HasValue
        ? $"{TempoFormatado}"
        : "Em andamento";

    /// <summary>
    /// Indicador de performance baseado no tempo
    /// </summary>
    public string IndicadorPerformance => (TempoEntregaHoras ?? TempoFinalizacaoHoras ?? 0) switch
    {
        <= 24 => "Excelente (1 dia)",
        <= 48 => "Bom (2 dias)",
        <= 120 => "Regular (5 dias)",
        _ => "Lento (> 5 dias)"
    };

    private static string FormatarTempo(double horas)
    {
        if (horas < 1)
            return $"{horas * 60:F0} minutos";

        if (horas < 24)
            return $"{horas:F1}h";

        var dias = (int)(horas / 24);
        var horasRestantes = horas % 24;

        if (horasRestantes < 1)
            return $"{dias} dia{(dias > 1 ? "s" : "")}";

        return $"{dias}d {horasRestantes:F1}h";
    }
}

/// <summary>
/// EstatÍ­sticas gerais de tempo médio
/// </summary>
public class EstatisticasGeraisDto
{
    public int TotalOrdensAnalisadas { get; set; }
    public int TotalOrdensFinalizadas { get; set; }
    public int TotalOrdensEntregues { get; set; }

    public double TempoMedioFinalizacaoHoras { get; set; }
    public double TempoMedioEntregaHoras { get; set; }

    /// <summary>
    /// Tempo médio formatado para exibição
    /// </summary>
    public string TempoMedioFormatado => FormatarTempoMedio(TempoMedioEntregaHoras);

    /// <summary>
    /// Performance geral da oficina
    /// </summary>
    public string PerformanceGeral => TempoMedioEntregaHoras switch
    {
        <= 24 => "Excelente",
        <= 48 => "Boa",
        <= 120 => "Regular",
        _ => "Precisa melhorar"
    };

    /// <summary>
    /// Resumo executivo
    /// </summary>
    public string ResumoExecutivo => TotalOrdensEntregues > 0
        ? $" {TotalOrdensEntregues} serviços concluÍ­dos | Tempo médio: {TempoMedioFormatado} | Performance: {PerformanceGeral}"
        : " Nenhum serviço concluÍ­do para análise";

    private static string FormatarTempoMedio(double horas)
    {
        if (horas < 1)
            return $"{horas * 60:F0} min";

        if (horas < 24)
            return $"{horas:F1} horas";

        var dias = horas / 24;
        return $"{dias:F1} dias ({horas:F1}h)";
    }
}

/// <summary>
/// Tempo médio por cliente
/// </summary>
public class TempoMedioPorClienteDto
{
    public int IdCliente { get; set; }
    public string NomeCliente { get; set; } = string.Empty;
    public int TotalOrdensEntregues { get; set; }
    public double TempoMedioHoras { get; set; }
    public decimal ValorMedioOrdem { get; set; }

    /// <summary>
    /// Tempo médio formatado
    /// </summary>
    public string TempoMedioFormatado => FormatarTempo(TempoMedioHoras);

    /// <summary>
    /// Performance do cliente
    /// </summary>
    public string Performance => TempoMedioHoras switch
    {
        <= 24 => " Excelente",
        <= 48 => " Bom",
        <= 120 => "  Regular",
        _ => " Lento"
    };

    /// <summary>
    /// ClassificaçÍo do cliente por complexidade de serviços
    /// </summary>
    public string ClassificacaoCliente => (ValorMedioOrdem, TempoMedioHoras) switch
    {
        ( > 1000, > 72) => " Cliente Premium - Serviços Complexos",
        ( > 500, <= 48) => " Cliente Eficiente - Bom Valor/Tempo",
        (_, <= 24) => "Cliente Rápido - Serviços Simples",
        _ => " Cliente padrão"
    };

    private static string FormatarTempo(double horas)
    {
        if (horas < 1)
            return $"{horas * 60:F0} min";

        if (horas < 24)
            return $"{horas:F1}h";

        var dias = horas / 24;
        return $"{dias:F1} dias";
    }
}