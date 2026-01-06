namespace OficinaCardozo.Domain.Exceptions;

public class ClienteNaoEncontradoException : DomainException
{
    public ClienteNaoEncontradoException(int id)
        : base($"Cliente com ID {id} não foi encontrado")
    {
    }
}

public class CpfCnpjJaCadastradoException : DomainException
{
    public CpfCnpjJaCadastradoException(string cpfCnpj)
        : base($"CPF/CNPJ {cpfCnpj} já está cadastrado no sistema")
    {
    }
}

public class CpfCnpjInvalidoException : DomainException
{
    public CpfCnpjInvalidoException(string cpfCnpj)
        : base($"CPF/CNPJ {cpfCnpj} possui formato inválido")
    {
    }
}

public abstract class DomainException : Exception
{
    protected DomainException(string message) : base(message) { }
    protected DomainException(string message, Exception innerException) : base(message, innerException) { }
}