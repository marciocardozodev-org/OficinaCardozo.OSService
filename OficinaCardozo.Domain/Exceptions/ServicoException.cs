namespace OficinaCardozo.Domain.Exceptions;

public class ServicoNaoEncontradoException : DomainException
{
    public ServicoNaoEncontradoException(int id)
        : base($"Serviço com ID {id} não foi encontrado")
    {
    }
}

public class NomeServicoJaCadastradoException : DomainException
{
    public NomeServicoJaCadastradoException(string nome)
        : base($"Serviço com nome '{nome}' já está cadastrado no sistema")
    {
    }
}

public class PrecoInvalidoException : DomainException
{
    public PrecoInvalidoException(decimal preco)
        : base($"Preço R$ {preco:F2} é inválido. Deve ser maior que zero")
    {
    }

    public PrecoInvalidoException(decimal preco, string mensagemAdicional)
        : base($"Preço R$ {preco:F2} é inválido. {mensagemAdicional}")
    {
    }
}