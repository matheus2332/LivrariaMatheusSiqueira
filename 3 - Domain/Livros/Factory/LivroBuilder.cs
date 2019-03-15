using Domain.Generos;
using System;

namespace Domain.Livros.Factory
{
    public class LivroBuilder : ILivroBuilder
    {
        private int? AnoDePublicacao { get; set; }
        private string Autor { get; set; }
        private string AutoresSecundarios { get; set; }
        private string Editora { get; set; }
        private Genero Genero { get; set; }
        private Guid Id { get; set; }
        private string Isbn { get; set; }
        private int? NumeroDaEdicao { get; set; }
        private int? NumeroDePaginas { get; set; }
        private int QuantidadeEmEstoque { get; set; }
        private string Serie { get; set; }
        private string SubTitulo { get; set; }
        private string Titulo { get; set; }

        public Livro Build() => new Livro(Id,
            AnoDePublicacao,
            Autor,
            AutoresSecundarios,
            Editora,
            Genero,
            Isbn,
            NumeroDaEdicao,
            NumeroDePaginas,
            QuantidadeEmEstoque,
            Serie,
            SubTitulo,
            Titulo);

        public LivroBuilder WithAnoDePublicacao(int? anoDePublicacao)
        {
            AnoDePublicacao = anoDePublicacao;
            return this;
        }

        public LivroBuilder WithAutor(string autor)
        {
            Autor = autor;
            return this;
        }

        public LivroBuilder WithAutoresSecundarios(string autoresSecundarios)
        {
            AutoresSecundarios = autoresSecundarios;
            return this;
        }

        public LivroBuilder WithEditora(string editora)
        {
            Editora = editora;
            return this;
        }

        public LivroBuilder WithGenero(Genero genero)
        {
            Genero = genero;
            return this;
        }

        public LivroBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public LivroBuilder WithIsbn(string isbn)
        {
            Isbn = isbn;
            return this;
        }

        public LivroBuilder WithNumeroDaEdicao(int? numeroDaEdicao)
        {
            NumeroDaEdicao = numeroDaEdicao;
            return this;
        }

        public LivroBuilder WithNumeroDePaginas(int? numeroDePaginas)
        {
            NumeroDePaginas = numeroDePaginas;
            return this;
        }

        public LivroBuilder WithQuantidadeEmEstoque(int quantidadeEmEstoque)
        {
            QuantidadeEmEstoque = quantidadeEmEstoque;
            return this;
        }

        public LivroBuilder WithSerie(string serie)
        {
            Serie = serie;
            return this;
        }

        public LivroBuilder WithSubTitulo(string subTitulo)
        {
            SubTitulo = subTitulo;
            return this;
        }

        public LivroBuilder WithTitulo(string titulo)
        {
            Titulo = titulo;
            return this;
        }
    }
}