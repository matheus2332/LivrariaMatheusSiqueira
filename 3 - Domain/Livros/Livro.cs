using System;
using CrossCutting.Base;
using Domain.Generos;

namespace Domain.Livros
{
    public class Livro : BaseEntity<Guid>, ILivro
    {
        public Livro(Guid id,
                     int? anoDePublicacao,
                     string autor,
                     string autoresSecundarios,
                     string editora,
                     Genero genero,
                     string isbn,
                     int? numeroDaEdicao,
                     int? numeroDePaginas,
                     int quantidadeEmEstoque,
                     string serie,
                     string subTitulo,
                     string titulo)
        {
            SetId(id);
            SetAnoDePublicacao(anoDePublicacao);
            SetAutor(autor);
            SetAutoresSecundarios(autoresSecundarios);
            SetDataDeCadastro(DateTime.Now);
            SetEditora(editora);
            SetGenero(genero);
            SetIsbn(isbn);
            SetNumeroDaEdicao(numeroDaEdicao);
            SetNumeroDePaginas(numeroDePaginas);
            SetQuantidadeEmEstoque(quantidadeEmEstoque);
            SetSerie(serie);
            SetSubTitulo(subTitulo);
            SetTitulo(titulo);
        }

        protected Livro()
        {
        }

        public int? AnoDePublicacao { get; private set; }

        public string Autor { get; private set; }

        public string AutoresSecundarios { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime? DataDeEdicao { get; private set; }

        public string Editora { get; private set; }

        public virtual Genero Genero { get; private set; }

        public Guid GeneroId { get; private set; }

        public string Isbn { get; private set; }

        public int? NumeroDaEdicao { get; private set; }

        public int? NumeroDePaginas { get; private set; }

        public int QuantidadeEmEstoque { get; private set; }

        public string Serie { get; private set; }

        public string SubTitulo { get; private set; }

        public string Titulo { get; private set; }

        public void SetAnoDePublicacao(int? anoDePublicacao)
        {
            if (anoDePublicacao > DateTime.Now.Year)
            {
                AddErro("O ano de publicação deve ser menor ou igual o ano atual.");
                return;
            }
            AnoDePublicacao = anoDePublicacao;
        }

        public void SetAutor(string autor)
        {
            if (string.IsNullOrWhiteSpace(autor))
            {
                AddErro("O autor deve ser informado.");
                return;
            }
            Autor = autor;
        }

        public void SetAutoresSecundarios(string autoresSecundarios)
        {
            AutoresSecundarios = autoresSecundarios;
        }

        public void SetDataDeCadastro(DateTime dataDeCadastro)
        {
            DataDeCadastro = dataDeCadastro;
        }

        public void SetDataDeEdicao(DateTime? dataDeEdicao)
        {
            DataDeEdicao = dataDeEdicao;
        }

        public void SetEditora(string editora)
        {
            if (string.IsNullOrWhiteSpace(editora))
            {
                AddErro("A editora do livro deve ser informada.");
                return;
            }
            Editora = editora;
        }

        public void SetGenero(Genero genero)
        {
            if (genero == null)
            {
                AddErro("O genero é obrigatório.");
                return;
            }

            Genero = genero;
            GeneroId = genero.Id;
        }

        public void SetIsbn(string isbn)
        {
            Isbn = isbn;
        }

        public void SetNumeroDaEdicao(int? numeroDaEdicao)
        {
            NumeroDaEdicao = numeroDaEdicao;
        }

        public void SetNumeroDePaginas(int? numeroDePaginas)
        {
            if (numeroDePaginas < 0)
            {
                AddErro("O numero de paginas dever ser maior ou igual a zero.");
                return;
            }
            NumeroDePaginas = numeroDePaginas;
        }

        public void SetQuantidadeEmEstoque(int quantidadeEmEstoque)
        {
            QuantidadeEmEstoque = quantidadeEmEstoque;
        }

        public void SetSerie(string serie)
        {
            Serie = serie;
        }

        public void SetSubTitulo(string subTitulo)
        {
            SubTitulo = subTitulo;
        }

        public void SetTitulo(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                AddErro("O titulo deve ser informado.");
                return;
            }
            Titulo = titulo;
        }
    }
}