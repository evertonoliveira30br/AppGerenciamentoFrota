using AppGerenciamentoFrota.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;

namespace AppGerenciamentoFrota
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cria coleção de serviços
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            //Cria o provedor de serviço
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //Executa o método Run da classe App
            serviceProvider.GetService<App>().Run();

        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            var environmentVariable = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

            if (string.IsNullOrEmpty(environmentVariable)) environmentVariable = "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json",optional:false,reloadOnChange:true)
                .AddJsonFile($"appsettings.{environmentVariable}.json",optional:true,reloadOnChange:true)
                .Build();          

            serviceCollection.AddDbContext<GerenciamentoFrotaContext>(options =>
               options.UseSqlite(configuration.GetConnectionString("SqliteConnectionString")));

            InjectorBootStrapper.Inicializar(serviceCollection);
        }
    }
}
