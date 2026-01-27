using OficinaCardozo.OSService.Application.DTOs;
using OficinaCardozo.OSService.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace OficinaCardozo.OSService.Application.Services;

public class EmailMonitorService : IEmailMonitorService
{
	public async Task<EmailStatusDto> MonitorarEmailAsync(string email)
	{
		// Implementação fictícia
		return new EmailStatusDto();
	}
}
