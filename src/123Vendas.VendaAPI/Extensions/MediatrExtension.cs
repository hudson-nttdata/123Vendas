using _123Vendas.Venda.Application.Features.Commands.Vendas.Criar;
using _123Vendas.Venda.Infrastructure.Repositories;
using System.Reflection;

namespace _123Vendas.VendaAPI.Extensions
{
    ///<inheritdoc/>
    public static class MediatrExtension
    {
        /// <summary>
        /// MediatR extension injection
        /// </summary>
        /// <param name="services"></param>
        public static void AddMediatRApi(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CriarVendaCommand).GetTypeInfo().Assembly));
        }
    }
}
