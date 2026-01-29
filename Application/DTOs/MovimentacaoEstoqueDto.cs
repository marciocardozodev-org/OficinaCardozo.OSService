namespace OficinaCardozo.OSService.Application.DTOs
{
    public class MovimentacaoEstoqueDto
    {
        public int PecaId { get; set; }
        public int Quantidade { get; set; }
        public string TipoMovimentacao { get; set; } // Entrada ou Saída
    }
}