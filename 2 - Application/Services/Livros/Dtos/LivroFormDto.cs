using Services.Dtos;
using System;

namespace Services.Livros.Dtos
{
    public class LivroFormDto : BaseDto
    {
        public int? AnoDePublicacao { get; set; }
        public string Autor { get; set; }
        public string AutoresSecundarios { get; set; }
        public string Editora { get; set; }
        public Guid GeneroId { get; set; }
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