using System;
using System.ComponentModel.DataAnnotations;

namespace OficinaCardozo.Application.DTOs
{
    public class TempoMedioExecucaoDto
    {
        /// <summary>
        /// Tempo médio total em dias (desde recebimento até entrega)
        /// </summary>
        public double TempoMedioTotalDias { get; set; }

        /// <summary>
        /// Tempo médio em horas (desde recebimento até entrega)
        /// </summary>
        public double TempoMedioTotalHoras { get; set; }

        /// <summary>
        /// Total de serviços concluídos (status "Entregue") no período
        /// </summary>
        public int TotalServicosConcluidos { get; set; }

        /// <summary>
        /// Data de início do período analisado
        /// </summary>
        public DateTime DataInicio { get; set; }

        /// <summary>
        /// Data de fim do período analisado
        /// </summary>
        public DateTime DataFim { get; set; }

        /// <summary>
        /// Tempo médio por fase do processo
        /// </summary>
        public FasesTempoMedioDto FasesDetalhadas { get; set; } = new();

        /// <summary>
        /// Detalhes dos serviços mais rápidos e mais lentos
        /// </summary>
        public ServicoTempoDetalheDto ServicoMaisRapido { get; set; } = new();
        public ServicoTempoDetalheDto ServicoMaisLento { get; set; } = new();
    }

    public class FasesTempoMedioDto
    {
        /// <summary>
        /// Tempo médio para diagnóstico (Recebida até Em execucao) - em horas
        /// </summary>
        public double TempoMedioDiagnosticoHoras { get; set; }

        /// <summary>
        /// Tempo médio de execução (Em execucao até Finalizada) - em horas
        /// </summary>
        public double TempoMedioExecucaoHoras { get; set; }

        /// <summary>
        /// Tempo médio para entrega (Finalizada até Entregue) - em horas
        /// </summary>
        public double TempoMedioEntregaHoras { get; set; }
    }

    public class ServicoTempoDetalheDto
    {
        public int IdOrdemServico { get; set; }
        public string ClienteNome { get; set; } = string.Empty;
        public string VeiculoPlaca { get; set; } = string.Empty;
        public string VeiculoMarcaModelo { get; set; } = string.Empty;
        public DateTime DataRecebimento { get; set; }
        public DateTime DataEntrega { get; set; }
        public double TotalDias { get; set; }
        public double TotalHoras { get; set; }
        public decimal ValorTotal { get; set; }
    }

    public class FiltroTempoMedioDto
    {
        /// <summary>
        /// Data de início para análise (opcional - padrão últimos 30 dias)
        /// </summary>
        public DateTime? DataInicio { get; set; }

        /// <summary>
        /// Data de fim para análise (opcional - padrão data atual)
        /// </summary>
        public DateTime? DataFim { get; set; }

        /// <summary>
        /// Filtrar por cliente específico (opcional)
        /// </summary>
        public int? IdCliente { get; set; }

        /// <summary>
        /// Incluir apenas serviços acima de determinado valor (opcional)
        /// </summary>
        public decimal? ValorMinimo { get; set; }
    }
}