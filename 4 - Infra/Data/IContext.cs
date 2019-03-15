using System.Data.Entity;
using Domain.Generos;
using Domain.Livros;

namespace Data
{
    public interface IContext
    {
        DbSet<Genero> Generos { get; set; }
        DbSet<Livro> Livros { get; set; }

        int SaveChanges();
    }
}