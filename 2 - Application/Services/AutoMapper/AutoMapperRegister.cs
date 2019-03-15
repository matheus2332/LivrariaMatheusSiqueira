using AutoMapper;
using Unity;

namespace Services.AutoMapper
{
    public class AutoMapperRegister
    {
        public static MapperConfiguration RegisterServices(IUnityContainer unityContainer)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ConstructServicesUsing(x => unityContainer.Resolve(x));
                cfg.AddProfile(new ServicesProfile());
            });

            return config;
        }
    }
}