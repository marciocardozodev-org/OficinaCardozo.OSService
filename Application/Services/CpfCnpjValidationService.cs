using OficinaCardozo.Domain.ValueObjects;
using OficinaCardozo.OSService.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace OficinaCardozo.OSService.Application.Services;

public class CpfCnpjValidationService : ICpfCnpjValidationService
{
	public bool ValidarCpfCnpj(string valor)
	{
		// Implementação de validação
		return !string.IsNullOrWhiteSpace(valor);
	}
	public string LimparFormatacao(string valor)
	{
		// Implementação de limpeza
		return valor.Replace(".", "").Replace("-", "").Replace("/", "");
	}
	public string FormatarCpfCnpj(string valor)
	{
		// Implementação de formatação
		return valor;
	}
}
