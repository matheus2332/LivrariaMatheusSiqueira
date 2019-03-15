using System;

namespace LivrariaWeb.Models
{
    public class LivroGridDataViewModel
    {
        public int? AnoDePublicacao { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Genero { get; set; }
        public Guid Id { get; set; }
        public string Titulo { get; set; }
    }
}