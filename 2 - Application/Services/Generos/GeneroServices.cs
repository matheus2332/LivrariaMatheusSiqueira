using Data;
using Domain.Generos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Generos
{
    public class GeneroServices : IGeneroServices
    {
        private readonly IContext _context;

        public GeneroServices(IContext context)
        {
            _context = context;
        }

        public Genero GetById(Guid id) => _context.Generos.FirstOrDefault(x => x.Id == id);

        public Dictionary<Guid, string> GetDropDown() => _context.Generos.Select(x => new
        {
            x.Id,
            x.Nome
        }).OrderBy(x => x.Nome)
        .ToDictionary(t => t.Id, t => t.Nome);
    }
}