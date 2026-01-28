namespace OficinaCardozo.OSService.Application.DTOs;

public class PecaDto
{
	public int Id { get; set; }
	public string NomePeca { get; set; } = string.Empty;
	public string CodigoIdentificador { get; set; } = string.Empty;
	public decimal Preco { get; set; }
	public int QuantidadeEstoque { get; set; }
	public string UnidadeMedida { get; set; } = string.Empty;
	public bool EstoqueBaixo { get; set; }
}
