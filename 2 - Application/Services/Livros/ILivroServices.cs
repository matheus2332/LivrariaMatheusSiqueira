using Domain.Livros;
using Services.Livros.Dtos;
using System;
using System.Collections.Generic;

namespace Services.Livros
{
    public interface ILivroServices
    {
        LivroFormDto Edit(LivroFormDto formDto);

        Livro GetById(Guid id);

        LivroFormDto GetFormDtoById(Guid id);

        List<LivroGridDataDto> GetGrid(string titulo);

        LivroFormDto Save(LivroFormDto formDto);
    }
}