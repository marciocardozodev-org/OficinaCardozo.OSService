using OficinaCardozo.Application.DTOs;
using OficinaCardozo.Application.Interfaces;
using OficinaCardozo.Domain.Entities;
using OficinaCardozo.Domain.Interfaces;
using OficinaCardozo.Domain.ValueObjects;
using OficinaCardozo.Domain.Exceptions;

namespace OficinaCardozo.Application.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IClienteMapper _clienteMapper;
    private readonly ICpfCnpjValidationService _cpfCnpjValidator;

    public ClienteService(
        IClienteRepository clienteRepository,
        IClienteMapper clienteMapper,
        ICpfCnpjValidationService cpfCnpjValidator)
    {
        _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        _clienteMapper = clienteMapper ?? throw new ArgumentNullException(nameof(clienteMapper));
        _cpfCnpjValidator = cpfCnpjValidator ?? throw new ArgumentNullException(nameof(cpfCnpjValidator));
    }

    public async Task<IEnumerable<ClienteDto>> ObterTodosClientesAsync()
    {
        var clientes = await _clienteRepository.ObterTodosAsync();
        return _clienteMapper.MapearParaListaDto(clientes);
    }

    public async Task<ClienteDto?> ObterClientePorIdAsync(int id)
    {
        ValidarId(id);

        var cliente = await _clienteRepository.ObterPorIdAsync(id);
        return cliente != null ? _clienteMapper.MapearParaDto(cliente) : null;
    }

    public async Task<ClienteDto> CriarClienteAsync(CreateClienteDto createDto)
    {
        ValidarDtoCreate(createDto);

        // CORREÇÃO: Passa o serviço de validação como segundo parâmetro
        var cpfCnpj = new CpfCnpj(createDto.CpfCnpj, _cpfCnpjValidator);
        await ValidarCpfCnpjUnicoAsync(cpfCnpj);

        var novoCliente = _clienteMapper.MapearParaEntidade(createDto);
        var clienteCriado = await _clienteRepository.CriarAsync(novoCliente);

        return _clienteMapper.MapearParaDto(clienteCriado);
    }

    public async Task<ClienteDto> AtualizarClienteAsync(int id, UpdateClienteDto updateDto)
    {
        ValidarId(id);
        ValidarDtoUpdate(updateDto);

        var cliente = await ObterClienteExistenteAsync(id);

        if (!string.IsNullOrWhiteSpace(updateDto.CpfCnpj))
        {
            // CORREÇÃO: Passa o serviço de validação como segundo parâmetro
            var novoCpfCnpj = new CpfCnpj(updateDto.CpfCnpj, _cpfCnpjValidator);
            await ValidarCpfCnpjUnicoParaAtualizacaoAsync(novoCpfCnpj, id);
        }

        _clienteMapper.AtualizarEntidadeComDto(cliente, updateDto);
        var clienteAtualizado = await _clienteRepository.AtualizarAsync(cliente);

        return _clienteMapper.MapearParaDto(clienteAtualizado);
    }

    public async Task<bool> RemoverClienteAsync(int id)
    {
        ValidarId(id);

        var clienteExiste = await _clienteRepository.ExisteAsync(id);
        if (!clienteExiste)
            throw new ClienteNaoEncontradoException(id);

        return await _clienteRepository.RemoverAsync(id);
    }

    private static void ValidarId(int id)
    {
        if (id <= 0)
            throw new ArgumentException("ID deve ser maior que zero", nameof(id));
    }

    private static void ValidarDtoCreate(CreateClienteDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        if (string.IsNullOrWhiteSpace(dto.Nome))
            throw new ArgumentException("Nome é obrigatório", nameof(dto.Nome));

        if (string.IsNullOrWhiteSpace(dto.CpfCnpj))
            throw new ArgumentException("CPF/CNPJ é obrigatório", nameof(dto.CpfCnpj));
    }

    private static void ValidarDtoUpdate(UpdateClienteDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
    }

    private async Task<Cliente> ObterClienteExistenteAsync(int id)
    {
        var cliente = await _clienteRepository.ObterPorIdAsync(id);
        return cliente ?? throw new ClienteNaoEncontradoException(id);
    }

    private async Task ValidarCpfCnpjUnicoAsync(CpfCnpj cpfCnpj)
    {
        if (await _clienteRepository.ExistePorCpfCnpjAsync(cpfCnpj.Valor))
            throw new CpfCnpjJaCadastradoException(cpfCnpj.Valor);
    }

    private async Task ValidarCpfCnpjUnicoParaAtualizacaoAsync(CpfCnpj cpfCnpj, int idClienteAtual)
    {
        if (await _clienteRepository.ExistePorCpfCnpjAsync(cpfCnpj.Valor, idClienteAtual))
            throw new CpfCnpjJaCadastradoException(cpfCnpj.Valor);
    }
}