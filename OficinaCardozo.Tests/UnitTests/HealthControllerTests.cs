using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using OficinaCardozo.API.Controllers;
using OficinaCardozo.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace OficinaCardozo.Tests.UnitTests.Controllers;

public class HealthControllerTests : IAsyncDisposable
{
    private readonly OficinaDbContext _context;
    private readonly HealthController _controller;

    public HealthControllerTests()
    {
        var services = new ServiceCollection();
        services.AddDbContext<OficinaDbContext>(options =>
            options.UseInMemoryDatabase($"TestDb_{Guid.NewGuid()}"));

        var serviceProvider = services.BuildServiceProvider();
        _context = serviceProvider.GetRequiredService<OficinaDbContext>();
        _controller = new HealthController(_context);
    }

    [Fact]
    public async Task Get_ComBancoConectado_DeveRetornarHealthy()
    {
        // Act
        var result = await _controller.Get();

        // Assert
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        var response = okResult.Value;

        response.Should().NotBeNull();
        response.GetType().GetProperty("status")?.GetValue(response).Should().Be("Healthy");
        response.GetType().GetProperty("database")?.GetValue(response).Should().Be("Connected");
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
        GC.SuppressFinalize(this);
    }
}