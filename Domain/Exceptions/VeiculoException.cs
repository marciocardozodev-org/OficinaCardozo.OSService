namespace OficinaCardozo.Domain.Exceptions;

public class VeiculoNaoEncontradoException : DomainException
{
    public VeiculoNaoEncontradoException(int id)
        : base($"Veículo com ID {id} não foi encontrado")
    {
    }
}

public class PlacaJaCadastradaException : DomainException
{
    public PlacaJaCadastradaException(string placa)
        : base($"Placa {placa} já está cadastrada no sistema")
    {
    }
}

public class PlacaInvalidaException : DomainException
{
    public PlacaInvalidaException(string placa)
        : base($"Placa {placa} possui formato inválido")
    {
    }
}

public class ClienteNaoExisteParaVeiculoException : DomainException
{
    public ClienteNaoExisteParaVeiculoException(int clienteId)
        : base($"Cliente com ID {clienteId} não existe para associar ao veículo")
    {
    }
}
