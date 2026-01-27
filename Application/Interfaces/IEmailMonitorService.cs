using OficinaCardozo.OSService.Application.DTOs;
using System.Threading.Tasks;

namespace OficinaCardozo.OSService.Application.Interfaces;

public interface IEmailMonitorService
{
    Task<EmailStatusDto> MonitorarEmailAsync(string email);
}
