namespace OficinaCardozo.OSService.Application.DTOs;

public class EstatisticasGeraisDto
{
	public int TotalOrdensAnalisadas { get; set; }
	public int TotalOrdensFinalizadas { get; set; }
	public int TotalOrdensEntregues { get; set; }
	public double TempoMedioFinalizacaoHoras { get; set; }
	public double TempoMedioEntregaHoras { get; set; }
	public string TempoMedioFormatado => FormatarTempoMedio(TempoMedioEntregaHoras);
	public string PerformanceGeral => TempoMedioEntregaHoras switch
	{
		<= 24 => "Excelente",
		<= 48 => "Boa",
		<= 120 => "Regular",
		_ => "Precisa melhorar"
	};
	public string ResumoExecutivo => TotalOrdensEntregues > 0
		? $"{TotalOrdensEntregues} serviços concluídos | Tempo médio: {TempoMedioFormatado} | Performance: {PerformanceGeral}"
		: "Nenhum serviço concluído para análise";
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
