using Aplicacao.Servico;
using Microsoft.Extensions.DependencyInjection;
using System;
using Titulo.Dominio.Entidades;
using Titulo.Dominio.Enum;
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


            string id = "118ED095-2248-4A04-94C6-899C0406FD98";


            //var filme = filmeServico.Obter(Guid.Parse(id));
            var filmes = filmeServico.ObterPorGenero(Genero.Terror);


            bool atualizou = filmeServico.Excluir(Guid.Parse(id));

            if (atualizou)
                Console.WriteLine("atualizou");

            //var filmes = filmeServico.ObterTodos();
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