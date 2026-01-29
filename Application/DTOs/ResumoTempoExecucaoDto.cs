namespace OficinaCardozo.OSService.Application.DTOs;

public class ResumoTempoExecucaoDto
{
	public List<OrdemServicoResumoDto> OrdensServico { get; set; } = new();
	public EstatisticasGeraisDto EstatisticasGerais { get; set; } = new();
	public List<TempoMedioPorClienteDto> TempoMedioPorCliente { get; set; } = new();
}

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
	public double? TempoFinalizacaoHoras => DataFinalizacao?.Subtract(DataSolicitacao).TotalHours;
	public double? TempoEntregaHoras => DataEntrega?.Subtract(DataSolicitacao).TotalHours;
	public string TempoFormatado => DataEntrega.HasValue
		? FormatarTempo(TempoEntregaHoras ?? 0)
		: DataFinalizacao.HasValue
		? $"{FormatarTempo(TempoFinalizacaoHoras ?? 0)} (aguardando entrega)"
		: "Em andamento";
	public string StatusTempo => DataEntrega.HasValue
		? $"Concluída em {TempoFormatado}"
		: DataFinalizacao.HasValue
		? $"{TempoFormatado}"
		: "Em andamento";
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


public class TempoMedioPorClienteDto
{
	public int IdCliente { get; set; }
	public string NomeCliente { get; set; } = string.Empty;
	public int TotalOrdensEntregues { get; set; }
	public double TempoMedioHoras { get; set; }
	public decimal ValorMedioOrdem { get; set; }
	public string TempoMedioFormatado => FormatarTempo(TempoMedioHoras);
	public string Performance => TempoMedioHoras switch
	{
		<= 24 => "Excelente",
		<= 48 => "Bom",
		<= 120 => "Regular",
		_ => "Lento"
	};
	public string ClassificacaoCliente => (ValorMedioOrdem, TempoMedioHoras) switch
	{
		(> 1000, > 72) => "Cliente Premium - Serviços Complexos",
		(> 500, <= 48) => "Cliente Eficiente - Bom Valor/Tempo",
		(_, <= 24) => "Cliente Rápido - Serviços Simples",
		_ => "Cliente padrão"
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
