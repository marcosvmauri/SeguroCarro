using SeguroCarro.Repository.Repository;
using SeguroCarro.Repository.Repository.Interfaces;
using SeguroCarro.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SeguroCarro.Service.Services;

namespace SeguroCarro.WebAPI
{
    public class Ioc
    {
        public static void AddRepositorysDependencies(IServiceCollection services)
        {
            services.AddTransient<ICarroRepository, CarroRepository>();
            services.AddTransient<ISeguradoRepository, SeguradoRepository>();
            services.AddTransient<ISeguroRepository, SeguroRepository>();
        }
        public static void AddServicesDependencies(IServiceCollection services)
        {
            services.AddTransient<ICarroService, CarroService>();
            services.AddTransient<ISeguradoService, SeguradoService>();
            services.AddTransient<ISeguroService, SeguroService>();
        }

    }
}
