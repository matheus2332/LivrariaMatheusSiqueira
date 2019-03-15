using CrossCutting.Strings;
using Data;
using Domain.Livros;
using Domain.Livros.Factory;
using Services.Generos;
using Services.Livros.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace Services.Livros
{
    public class LivrosServices : ILivroServices
    {
        private readonly IContext _context;
        private readonly IGeneroServices _generoServices;
        private readonly ILivroBuilder _livroBuilder;

        public LivrosServices(IContext context, IGeneroServices generoServices, ILivroBuilder livroBuilder)
        {
            _context = context;
            _generoServices = generoServices;
            _livroBuilder = livroBuilder;
        }

        public LivroFormDto Edit(LivroFormDto formDto)
        {
            if (!Validar(formDto))
            {
                return formDto;
            }

            var livro = EditarLivro(formDto);
            if (!livro.IsValid)
            {
                formDto.AddErro("", string.Join(", ", livro.Erros));
                return formDto;
            }

            _context.SaveChanges();
            return formDto;
        }

        public Livro GetById(Guid id) => _context.Livros.FirstOrDefault(x => x.Id == id);

        public LivroFormDto GetFormDtoById(Guid id) => _context.Livros.Where(x => x.Id == id)
            .Select(x => new LivroFormDto
            {
                Id = x.Id,
                AnoDePublicacao = x.AnoDePublicacao,
                Autor = x.Autor,
                AutoresSecundarios = x.AutoresSecundarios,
                Editora = x.Editora,
                GeneroId = x.GeneroId,
                Isbn = x.Isbn,
                NumeroDaEdicao = x.NumeroDaEdicao,
                NumeroDePaginas = x.NumeroDePaginas,
                QuantidadeEmEstoque = x.QuantidadeEmEstoque,
                Serie = x.Serie,
                SubTitulo = x.SubTitulo,
                Titulo = x.Titulo,
            }).FirstOrDefault();

        public LivroFormDto Save(LivroFormDto formDto)
        {
            if (!Validar(formDto))
            {
                return formDto;
            }

            var livro = CriarLivro(formDto);
            if (!livro.IsValid)
            {
                formDto.AddErro("", string.Join(", ", livro.Erros));
                return formDto;
            }

            _context.Livros.Add(livro);
            _context.SaveChanges();
            return formDto;
        }

        public List<LivroGridDataDto> GetGrid(string titulo)
        {
            var query = _context.Livros.AsQueryable();
            if (string.IsNullOrWhiteSpace(titulo))
            {
                var parametro = titulo.TextoToQuery();
                query = query.Where(g => SqlFunctions.PatIndex(parametro, g.Titulo.ToLower()) > 0);
            }

            return query
            .OrderBy(x => x.Titulo)
            .Select(x => new LivroGridDataDto
            {
                AnoDePublicacao = x.AnoDePublicacao,
                Autor = x.Autor,
                Editora = x.Editora,
                Genero = x.Genero.Nome,
                Id = x.Id,
                Titulo = x.Titulo
            }).ToList();
        }

        private Livro CriarLivro(LivroFormDto formDto)
        {
            var genero = _generoServices.GetById(formDto.GeneroId);

            return _livroBuilder.
                        WithId(Guid.NewGuid()).
                        WithAnoDePublicacao(formDto.AnoDePublicacao).
                        WithAutor(formDto.Autor).
                        WithAutoresSecundarios(formDto.AutoresSecundarios).
                        WithEditora(formDto.Editora).
                        WithGenero(genero).
                        WithIsbn(formDto.Isbn).
                        WithNumeroDaEdicao(formDto.NumeroDaEdicao).
                        WithNumeroDePaginas(formDto.NumeroDePaginas).
                        WithQuantidadeEmEstoque(formDto.QuantidadeEmEstoque).
                        WithSerie(formDto.Serie).
                        WithSubTitulo(formDto.SubTitulo).
                        WithTitulo(formDto.Titulo).
                        Build();
        }

        private Livro EditarLivro(LivroFormDto formDto)
        {
            var livro = GetById(formDto.Id);
            if (livro == null) return null;
            var genero = _generoServices.GetById(formDto.GeneroId);

            livro.SetAnoDePublicacao(formDto.AnoDePublicacao);
            livro.SetAutor(formDto.Autor);
            livro.SetAutoresSecundarios(formDto.AutoresSecundarios);
            livro.SetEditora(formDto.Editora);
            livro.SetGenero(genero);
            livro.SetIsbn(formDto.Isbn);
            livro.SetNumeroDaEdicao(formDto.NumeroDaEdicao);
            livro.SetNumeroDePaginas(formDto.NumeroDePaginas);
            livro.SetQuantidadeEmEstoque(formDto.QuantidadeEmEstoque);
            livro.SetSerie(formDto.Serie);
            livro.SetSubTitulo(formDto.SubTitulo);
            livro.SetTitulo(formDto.Titulo);
            livro.SetDataDeEdicao(DateTime.Now);

            return livro;
        }

        private bool Validar(LivroFormDto formDto)
        {
            if (formDto.AnoDePublicacao.HasValue && formDto.AnoDePublicacao > DateTime.Now.Year)
            {
                formDto.AddErro(nameof(formDto.AnoDePublicacao), "O ano de publicação não pode ser maior que o ano atual.");
            }
            if (string.IsNullOrWhiteSpace(formDto.Titulo))
            {
                formDto.AddErro(nameof(formDto.Titulo), "O título do livro deve ser informado.");
            }
            if (string.IsNullOrWhiteSpace(formDto.Autor))
            {
                formDto.AddErro(nameof(formDto.Autor), "O autor do livro deve ser informado.");
            }
            if (string.IsNullOrWhiteSpace(formDto.Editora))
            {
                formDto.AddErro(nameof(formDto.Editora), "A editora do livro deve ser informada.");
            }

            return formDto.IsValid;
        }
    }
}