using System;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using Domain.Livros.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Generos;
using Services.Livros;
using Services.Livros.Dtos;

namespace Tests
{
    [TestClass]
    public class LivroServicesTests
    {
        [TestMethod]
        public void Savar_livro_com_todos_dados()
        {
            var context = new Data.Context();

            var formDto = new LivroFormDto
            {
                AnoDePublicacao = 2018,
                Autor = "Christian Nagel",
                Editora = "Wrox",
                Isbn = "1119449278",
                AutoresSecundarios = "outro autor",
                GeneroId = context.Generos.Select(x => x.Id).FirstOrDefault(),
                NumeroDaEdicao = 78,
                NumeroDePaginas = 856,
                QuantidadeEmEstoque = 8,
                Serie = "20",
                SubTitulo = ".NetCore",
                Titulo = "Professional C# 7"
            };
            var services = new LivrosServices(context, new GeneroServices(context), new LivroBuilder());
            var dto = services.Save(formDto);
            Assert.IsTrue(dto.IsValid);
        }

        [TestMethod]
        public void Editar_livro_com_todos_dados()
        {
            var context = new Data.Context();
            var id = context.Livros.Select(x => x.Id).FirstOrDefault();

            var formDto = new LivroFormDto
            {
                AnoDePublicacao = 2010,
                Autor = "Christian Nagel editado",
                Editora = "Wrox editado",
                Isbn = "1119449278 editado",
                AutoresSecundarios = "outro autor editado",
                GeneroId = context.Generos.Select(x => x.Id).FirstOrDefault(),
                NumeroDaEdicao = 99,
                NumeroDePaginas = 999,
                QuantidadeEmEstoque = 10,
                Serie = "20 editado",
                SubTitulo = ".NetCore editado",
                Titulo = "Professional C# 7 editado",

                Id = id
            };
            var services = new LivrosServices(context, new GeneroServices(context), new LivroBuilder());
            var dto = services.Edit(formDto);
            Assert.IsTrue(dto.IsValid);
        }

        [TestMethod]
        public void Editar_livro_com_dados_minimos()
        {
            var context = new Data.Context();
            var id = context.Livros.Select(x => x.Id).FirstOrDefault();

            var formDto = new LivroFormDto
            {
                Autor = "Christian Nagel editado",
                Editora = "Wrox editado",
                GeneroId = context.Generos.Select(x => x.Id).FirstOrDefault(),
                Titulo = "Professional C# 7 editado",

                Id = id
            };
            var services = new LivrosServices(context, new GeneroServices(context), new LivroBuilder());
            var dto = services.Edit(formDto);
            Assert.IsTrue(dto.IsValid);
        }

        [TestMethod]
        public void Salvar_livro_com_dados_minimos()
        {
            var context = new Data.Context();
            var id = context.Livros.Select(x => x.Id).FirstOrDefault();

            var formDto = new LivroFormDto
            {
                Autor = "Christian Nagel",
                Editora = "Wrox",
                GeneroId = context.Generos.Select(x => x.Id).FirstOrDefault(),
                Titulo = "Professional C# 7",

                Id = id
            };
            var services = new LivrosServices(context, new GeneroServices(context), new LivroBuilder());
            var dto = services.Edit(formDto);
            Assert.IsTrue(dto.IsValid);
        }

        [TestMethod]
        public void Salvar_livro_com_ano_de_publicacao_maior_que_o_atual()
        {
            var context = new Data.Context();
            var id = context.Livros.Select(x => x.Id).FirstOrDefault();

            var formDto = new LivroFormDto
            {
                Autor = "Christian Nagel",
                Editora = "Wrox",
                GeneroId = context.Generos.Select(x => x.Id).FirstOrDefault(),
                Titulo = "Professional C# 7",
                AnoDePublicacao = DateTime.Now.Year + 1,
                Id = id
            };
            var services = new LivrosServices(context, new GeneroServices(context), new LivroBuilder());
            var dto = services.Edit(formDto);
            Assert.IsFalse(dto.IsValid);
        }

        [TestMethod]
        public void Salvar_livro_com_ano_de_publicacao_igual_o_atual()
        {
            var context = new Data.Context();
            var id = context.Livros.Select(x => x.Id).FirstOrDefault();

            var formDto = new LivroFormDto
            {
                Autor = "Christian Nagel",
                Editora = "Wrox",
                GeneroId = context.Generos.Select(x => x.Id).FirstOrDefault(),
                Titulo = "Professional C# 7",
                AnoDePublicacao = DateTime.Now.Year,
                Id = id
            };
            var services = new LivrosServices(context, new GeneroServices(context), new LivroBuilder());
            var dto = services.Edit(formDto);
            Assert.IsTrue(dto.IsValid);
        }

        [TestMethod]
        public void GridTests()
        {
            var context = new Data.Context();

            var services = new LivrosServices(context, new GeneroServices(context), new LivroBuilder());
            var a = services.GetGrid(null);
        }
    }
}