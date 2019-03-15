using AutoMapper;
using Microsoft.Practices.Unity;
using Services.AutoMapper;

namespace LivrariaWeb.Mapper
{
    public class AutoMapperRegister
    {
        public static MapperConfiguration RegisterServices(IUnityContainer unityContainer)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ConstructServicesUsing(x => unityContainer.Resolve(x));
                cfg.AddProfile(new WebProfile());
                cfg.AddProfile(new ServicesProfile());
            });

            return config;
        }
    }
}