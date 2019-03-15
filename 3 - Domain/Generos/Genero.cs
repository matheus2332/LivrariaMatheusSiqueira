using CrossCutting.Base;
using System;

namespace Domain.Generos
{
    public class Genero : BaseEntity<Guid>, IGenero
    {
        public Genero(Guid id, string nome)
        {
            SetId(id);
            SetNome(nome);
        }

        protected Genero()
        {
        }

        public string Nome { get; private set; }

        public void SetNome(string nome)
        {
            Nome = nome;
        }
    }
}