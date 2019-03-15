using Domain.Generos;
using System;

namespace Domain.Livros.Factory
{
    public interface ILivroBuilder
    {
        Livro Build();

        LivroBuilder WithAnoDePublicacao(int? anoDePublicacao);

        LivroBuilder WithAutor(string autor);

        LivroBuilder WithAutoresSecundarios(string autoresSecundarios);

        LivroBuilder WithEditora(string editora);

        LivroBuilder WithGenero(Genero genero);

        LivroBuilder WithId(Guid id);

        LivroBuilder WithIsbn(string isbn);

        LivroBuilder WithNumeroDaEdicao(int? numeroDaEdicao);

        LivroBuilder WithNumeroDePaginas(int? numeroDePaginas);

        LivroBuilder WithQuantidadeEmEstoque(int quantidadeEmEstoque);

        LivroBuilder WithSerie(string serie);

        LivroBuilder WithSubTitulo(string subTitulo);

        LivroBuilder WithTitulo(string titulo);
    }
}