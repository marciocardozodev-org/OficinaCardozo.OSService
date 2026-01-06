using OficinaCardozo.Application.DTOs;

namespace OficinaCardozo.Application.Services;

public interface IAutenticacaoService
{
    Task<TokenRespostaDto> FazerLoginAsync(LoginDto loginDto);

    Task<TokenRespostaDto> FazerLoginPorCpfAsync(LoginCpfDto loginCpfDto);

    Task<UsuarioDto> CriarUsuarioAsync(CriarUsuarioDto criarUsuarioDto);

    Task<UsuarioDto> AtualizarUsuarioAsync(int id, AtualizarUsuarioDto atualizarUsuarioDto);

    Task<bool> ExcluirUsuarioAsync(int id);

    Task<IEnumerable<UsuarioDto>> ObterTodosUsuariosAsync();

  
    Task<UsuarioDto?> ObterUsuarioPorIdAsync(int id);

   
    Task<bool> ValidarTokenAsync(string token);

   
    string GerarTokenJwt(UsuarioDto usuario);
}