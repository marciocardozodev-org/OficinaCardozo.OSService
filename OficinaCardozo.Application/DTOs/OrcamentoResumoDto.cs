namespace OficinaCardozo.Application.DTOs;

/// <summary>
/// DTO para resumo de orçamento (usado em operações de aprovação)
/// </summary>
public class OrcamentoResumoDto
{
    /// <summary>
    /// ID do orçamento
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Data de criaçÍo do orçamento
    /// </summary>
    public DateTime DataOrcamento { get; set; }

    /// <summary>
    /// Descrição do status atual
    /// </summary>
    public string StatusDescricao { get; set; } = string.Empty;

    /// <summary>
    /// Nome do cliente
    /// </summary>
    public string ClienteNome { get; set; } = string.Empty;

    /// <summary>
    /// E-mail do cliente
    /// </summary>
    public string ClienteEmail { get; set; } = string.Empty;

    /// <summary>
    /// Placa do veículo
    /// </summary>
    public string VeiculoPlaca { get; set; } = string.Empty;

    /// <summary>
    /// Marca e modelo do veículo
    /// </summary>
    public string VeiculoMarcaModelo { get; set; } = string.Empty;

    /// <summary>
    /// Valor total do orçamento
    /// </summary>
    public decimal ValorTotal { get; set; }

    /// <summary>
    /// Mensagem sobre o status/aprovação do orçamento
    /// </summary>
    public string MensagemAprovacao { get; set; } = string.Empty;

    /// <summary>
    /// FormataçÍo do valor para exibição
    /// </summary>
    public string ValorFormatado => ValorTotal.ToString("C2");

    /// <summary>
    /// Data formatada para exibição
    /// </summary>
    public string DataFormatada => DataOrcamento.ToString("dd/MM/yyyy HH:mm");
}