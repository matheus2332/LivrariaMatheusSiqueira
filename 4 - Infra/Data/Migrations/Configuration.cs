namespace Data.Migrations
{
    using Domain.Generos;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            var generos = new List<Genero>
            {
                new Genero(Guid.NewGuid(), "Autobiografia"),
                new Genero(Guid.NewGuid(), "Biografia"),
                new Genero(Guid.NewGuid(), "Fantasia"),
                new Genero(Guid.NewGuid(), "Ficção Científica"),
                new Genero(Guid.NewGuid(), "Revista"),
                new Genero(Guid.NewGuid(), "Gibi"),
                new Genero(Guid.NewGuid(), "Terror"),
                new Genero(Guid.NewGuid(), "Literatura Infanto-Juvenil"),
                new Genero(Guid.NewGuid(), "Paródia"),
                new Genero(Guid.NewGuid(), "Suspense"),
                new Genero(Guid.NewGuid(), "Religioso"),
                new Genero(Guid.NewGuid(), "Trilogias"),
                new Genero(Guid.NewGuid(), "Sagas"),
            };

            generos.ForEach(s => context.Generos.Add(s));
            context.SaveChanges();
        }
    }
}