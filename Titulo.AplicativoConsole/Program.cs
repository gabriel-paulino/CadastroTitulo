using Aplicacao.Servico;
using Microsoft.Extensions.DependencyInjection;
using Titulo.Dominio.Interfaces.Repositorios;
using Titulo.Dominio.Interfaces.Servicos;
using Titulo.Repositorio.Data;
using Titulo.Repositorio.Repositorios;

namespace CadastroTitulo
{
    class Program
    {
        private static ServiceCollection _collection = new();

        static void Main(string[] args)
        {
            RegisterServices();
            var service = _collection.BuildServiceProvider();

            var filmeServico = service.GetService<IFilmeServico>();

            var filmes = filmeServico.ObterTodos();
        }

        private static void RegisterServices() =>
            _collection
                .AddScoped<DbSession>()
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<IFilmeRepositorio, FilmeRepositorio>()
                .AddTransient<ISerieRepositorio, SerieRepositorio>()
                .AddTransient<IFilmeServico, FilmeServico>()
                .AddTransient<ISerieServico, SerieServico>();
    }
}