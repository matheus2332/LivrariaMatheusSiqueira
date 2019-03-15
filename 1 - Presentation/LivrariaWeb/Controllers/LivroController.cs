using LivrariaWeb.Models;
using LivrariaWeb.Models.Base;
using Services.Dtos;
using Services.Generos;
using Services.Livros;
using Services.Livros.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LivrariaWeb.Controllers
{
    public class LivroController : Controller
    {
        private readonly IGeneroServices _generoServices;
        private readonly ILivroServices _livroServices;

        public LivroController(ILivroServices livroServices, IGeneroServices generoServices)
        {
            _generoServices = generoServices;
            _livroServices = livroServices;
        }

        [HttpGet]
        public ActionResult Editar(Guid id)
        {
            var dto = _livroServices.GetFormDtoById(id);
            var viewModel = MontarViewModel(dto);
            return View("Editar", SetFormViewModel(viewModel));
        }

        [HttpPost]
        public ActionResult Editar(LivroFormViewModel formViewModel)
        {
            var dto = new LivroFormDto
            {
                Id = formViewModel.Id,

                AnoDePublicacao = formViewModel.AnoDePublicacao,
                Autor = formViewModel.Autor,
                AutoresSecundarios = formViewModel.AutoresSecundarios,
                Editora = formViewModel.Editora,
                GeneroId = formViewModel.GeneroId,
                Isbn = formViewModel.Isbn,
                NumeroDaEdicao = formViewModel.NumeroDaEdicao,
                NumeroDePaginas = formViewModel.NumeroDePaginas,
                QuantidadeEmEstoque = formViewModel.QuantidadeEmEstoque,
                Serie = formViewModel.Serie,
                SubTitulo = formViewModel.SubTitulo,
                Titulo = formViewModel.Titulo,
            };

            var formDto = _livroServices.Edit(dto);
            if (!formDto.IsValid)
            {
                AdicionarErrosDoValidatorNoModelState(formDto);
                var viewModel = SetFormViewModel(MontarViewModel(formDto));
                return View("Novo", viewModel);
            }
            return Index();
        }

        // GET: Livros
        public ActionResult Index()
        {
            var livros = _livroServices.GetGrid(null);
            var viewModel = new LivroGridViewModel
            {
                Livros = livros.Select(x => new LivroGridDataViewModel
                {
                    AnoDePublicacao = x.AnoDePublicacao,
                    Autor = x.Autor,
                    Editora = x.Editora,
                    Genero = x.Genero,
                    Id = x.Id,
                    Titulo = x.Titulo
                }).ToList()
            };
            return View("Index", viewModel);
        }

        [HttpGet]
        public ActionResult Novo()
        {
            return View("Novo", SetFormViewModel(new LivroFormViewModel()));
        }

        [HttpPost]
        public ActionResult Novo(LivroFormViewModel formViewModel)
        {
            var dto = new LivroFormDto
            {
                AnoDePublicacao = formViewModel.AnoDePublicacao,
                Autor = formViewModel.Autor,
                AutoresSecundarios = formViewModel.AutoresSecundarios,
                Editora = formViewModel.Editora,
                GeneroId = formViewModel.GeneroId,
                Isbn = formViewModel.Isbn,
                NumeroDaEdicao = formViewModel.NumeroDaEdicao,
                NumeroDePaginas = formViewModel.NumeroDePaginas,
                QuantidadeEmEstoque = formViewModel.QuantidadeEmEstoque,
                Serie = formViewModel.Serie,
                SubTitulo = formViewModel.SubTitulo,
                Titulo = formViewModel.Titulo,
            };

            var formDto = _livroServices.Save(dto);
            if (!formDto.IsValid)
            {
                AdicionarErrosDoValidatorNoModelState(formDto);
                var viewModel = SetFormViewModel(MontarViewModel(formDto));
                return View("Novo", viewModel);
            }
            return Index();
        }

        public ActionResult Delete(Guid id)
        {
            _livroServices.Delete(id);
            return Index();
        }

        private void AdicionarErrosDoValidatorNoModelState(BaseDto dto)
        {
            if (dto.Erros == null || !dto.Erros.Any()) return;
            dto.Erros.ToList()
                .ForEach(x => ModelState.AddModelError(x.PropertyName, x.Erro));
        }

        private Dictionary<Guid, string> GetGeneros() => _generoServices.GetDropDown();

        private LivroFormViewModel MontarViewModel(LivroFormDto dto)
        {
            return new LivroFormViewModel
            {
                Id = dto.Id,
                AnoDePublicacao = dto.AnoDePublicacao,
                Autor = dto.Autor,
                AutoresSecundarios = dto.AutoresSecundarios,
                Editora = dto.Editora,
                GeneroId = dto.GeneroId,
                Isbn = dto.Isbn,
                NumeroDaEdicao = dto.NumeroDaEdicao,
                NumeroDePaginas = dto.NumeroDePaginas,
                QuantidadeEmEstoque = dto.QuantidadeEmEstoque,
                Serie = dto.Serie,
                SubTitulo = dto.SubTitulo,
                Titulo = dto.Titulo,
                Erros = dto.Erros.Select(x => x.Erro).ToList()
            };
        }

        private LivroFormViewModel SetFormViewModel(LivroFormViewModel formViewModel)
        {
            formViewModel.Generos = GetGeneros();
            return formViewModel;
        }
    }
}