using LivrariaWeb.Models.Base;
using System;
using System.Collections.Generic;

namespace LivrariaWeb.Models
{
    public class LivroFormViewModel : BaseViewModel
    {
        public int? AnoDePublicacao { get; set; }
        public string Autor { get; set; }
        public string AutoresSecundarios { get; set; }
        public string Editora { get; set; }
        public Guid GeneroId { get; set; }
        public Dictionary<Guid, string> Generos { get; set; }
        public Guid Id { get; set; }
        public string Isbn { get; set; }
        public int? NumeroDaEdicao { get; set; }
        public int? NumeroDePaginas { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public string Serie { get; set; }
        public string SubTitulo { get; set; }
        public string Titulo { get; set; }
    }
}