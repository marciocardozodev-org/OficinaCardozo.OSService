using FluentAssertions;
using OficinaCardozo.Application.Services;
using Xunit;

namespace OficinaCardozo.Tests.UnitTests.Services;

public class CpfCnpjValidationServiceTests
{
    private readonly CpfCnpjValidationService _service;

    public CpfCnpjValidationServiceTests()
    {
        _service = new CpfCnpjValidationService();
    }

    [Theory]
    [InlineData("11144477735", true)]
    [InlineData("111.444.777-35", true)]
    [InlineData("00000000000", false)]
    [InlineData("12345678901", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void ValidarCpf_DeveRetornarResultadoCorreto(string cpf, bool esperado)
    {
        // Act
        var resultado = _service.ValidarCpf(cpf);

        // Assert
        resultado.Should().Be(esperado);
    }

    [Theory]
    [InlineData("111.444.777-35", "11144477735")]
    [InlineData("11.222.333/0001-81", "11222333000181")]
    [InlineData("abc123def456", "123456")]
    public void LimparFormatacao_DeveRemoverCaracteresNaoNumericos(string entrada, string esperado)
    {
        // Act
        var resultado = _service.LimparFormatacao(entrada);

        // Assert
        resultado.Should().Be(esperado);
    }

    [Theory]
    [InlineData("11144477735", "111.444.777-35")]
    [InlineData("12345678901", "123.456.789-01")]
    public void FormatarCpf_DeveFormatarCorretamente(string cpf, string esperado)
    {
        // Act
        var resultado = _service.FormatarCpf(cpf);

        // Assert
        resultado.Should().Be(esperado);
    }

    [Theory]
    [InlineData("11222333000181", "11.222.333/0001-81")]
    [InlineData("12345678000195", "12.345.678/0001-95")]
    public void FormatarCnpj_DeveFormatarCorretamente(string cnpj, string esperado)
    {
        // Act
        var resultado = _service.FormatarCnpj(cnpj);

        // Assert
        resultado.Should().Be(esperado);
    }
}