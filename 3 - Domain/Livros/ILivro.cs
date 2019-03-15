using Domain.Generos;
using System;

namespace Domain.Livros
{
    public interface ILivro
    {
        int? AnoDePublicacao { get; }
        string Autor { get; }
        string AutoresSecundarios { get; }
        string Editora { get; }
        Genero Genero { get; }
        Guid GeneroId { get; }
        string Isbn { get; }
        int? NumeroDaEdicao { get; }
        int? NumeroDePaginas { get; }
        int QuantidadeEmEstoque { get; }
        string Serie { get; }
        string SubTitulo { get; }
        string Titulo { get; }
    }
}