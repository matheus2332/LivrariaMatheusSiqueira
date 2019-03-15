using System;

namespace Domain.Generos
{
    public interface IGenero
    {
        string Nome { get; }
        Guid Id { get; }
    }
}