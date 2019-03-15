using Domain.Generos;
using System;
using System.Collections.Generic;

namespace Services.Generos
{
    public interface IGeneroServices
    {
        Genero GetById(Guid id);
        Dictionary<Guid, string> GetDropDown();
    }
}