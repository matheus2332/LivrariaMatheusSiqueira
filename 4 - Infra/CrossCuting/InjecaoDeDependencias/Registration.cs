using Microsoft.Practices.Unity;
using Data;
using Services.Generos;
using Services.Livros;
using Domain.Livros.Factory;

namespace DependencyInjection
{
    public class Registration
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<IContext, Context>(new PerThreadLifetimeManager());
            container.RegisterType<ILivroBuilder, LivroBuilder>(new PerThreadLifetimeManager());
            container.RegisterType<ILivroServices, LivrosServices>(new PerThreadLifetimeManager());
            container.RegisterType<IGeneroServices, GeneroServices>(new PerThreadLifetimeManager());
        }
    }
}