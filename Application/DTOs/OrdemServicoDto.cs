namespace OficinaCardozo.OSService.Application.DTOs;

public class OrdemServicoDto
{
    public int Id { get; set; }
    public DateTime DataSolicitacao { get; set; }
    public int IdVeiculo { get; set; }
    public int IdStatus { get; set; }
    public string? StatusDescricao { get; set; }
    public DateTime? DataFinalizacao { get; set; }
    public DateTime? DataEntrega { get; set; }
    public TimeSpan? TempoTotalExecucao => DataFinalizacao.HasValue ? DataFinalizacao.Value - DataSolicitacao : null;
    public TimeSpan? TempoTotalEntrega => DataEntrega.HasValue ? DataEntrega.Value - DataSolicitacao : null;
    public string VeiculoPlaca { get; set; } = string.Empty;
    public string VeiculoMarcaModelo { get; set; } = string.Empty;
    public string ClienteNome { get; set; } = string.Empty;
    public string ClienteEmail { get; set; } = string.Empty;
    // ...continuação dos campos do DTO...
}
