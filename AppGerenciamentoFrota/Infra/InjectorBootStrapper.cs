using AppGerenciamentoFrota.Data.Repositories;
using AppGerenciamentoFrota.Domain;
using AppGerenciamentoFrota.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AppGerenciamentoFrota.Infra
{
    public static class InjectorBootStrapper
    {
        public static void Inicializar(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<App>();
            serviceCollection.AddTransient<IGerenciamentoFrotaBll, GerenciamentoFrotaBll>();
            serviceCollection.AddTransient<IVeiculoRepository, VeiculoRepository>();

            serviceCollection.AddSingleton<GerenciamentoFrotaContext>();
        }
    }
}
