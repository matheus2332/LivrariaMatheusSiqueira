using Domain.Generos;
using Domain.Livros;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data
{
    public class Context : DbContext, IContext
    {
        // Your context has been configured to use a 'Context' connection string from your application's
        // configuration file (App.config or Web.config). By default, this connection string targets the
        // 'Data.Context' database on your LocalDb instance.
        //
        // If you wish to target a different database and/or database provider, modify the 'Context'
        // connection string in the application configuration file.
        public Context()
            : base("Context")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}