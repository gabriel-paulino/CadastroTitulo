using Aplicacao.Servico;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
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
        private static IFilmeServico _filmeServico;

        static void Main(string[] args)
        {
            RegisterServices();
            var service = _collection.BuildServiceProvider();

            _filmeServico = service.GetService<IFilmeServico>();

            string opcao = ObterOpcaoUsuario();

            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "C":
                        LimparTela();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcao = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Filmes a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar filmes");
            Console.WriteLine("2- Inserir filme");
            Console.WriteLine("3- Atualizar filme");
            Console.WriteLine("4- Excluir filme");
            Console.WriteLine("5- Detalhes filme");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarFilmes()
        {
            Console.WriteLine("Listar filmes:");

            var filmes = _filmeServico.ObterTodos();

            if (!filmes.Any())
            {
                Console.WriteLine("Nenhuma filme cadastrado.");
                return;
            }

            foreach (var filme in filmes)
                Console.WriteLine($"#Id {filme.Id}: - {filme.Titulo} {(filme.Excluido ? "*Excluído*" : string.Empty)}");
        }

        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme");

            foreach (int i in Enum.GetValues(typeof(Genero)))
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a data de lançamento da filme: ");
            var entradaLancamento = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new(
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                lancamento: entradaLancamento,
                descricao: entradaDescricao);

            _filmeServico.Inserir(novoFilme);
        }

        private static void AtualizarFilme()
        {
            Console.Write("Digite o titulo do filme: ");
            string titulo = Console.ReadLine();

            var filme = _filmeServico.ObterPorTitulo(titulo).FirstOrDefault();

            foreach (int i in Enum.GetValues(typeof(Genero)))
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o novo título do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a nova data de lançamento do filme: ");
            var entradaLancamento = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite a nova descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            var atualizaFilme = new Filme(
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                lancamento: entradaLancamento,
                descricao: entradaDescricao);

            _filmeServico.Atualizar(filme.Id, atualizaFilme);
        }

        private static void ExcluirFilme()
        {
            Console.Write("Digite o título do filme: ");
            string titulo = Console.ReadLine();

            var filme = _filmeServico.ObterPorTitulo(titulo).FirstOrDefault();

            _filmeServico.Excluir(filme.Id);
        }

        private static void VisualizarFilme()
        {
            Console.Write("Digite o título do filme: ");
            string titulo = Console.ReadLine();

            var filme = _filmeServico.ObterPorTitulo(titulo).FirstOrDefault();

            string detalhes = $"Gênero: {filme.Genero} {Environment.NewLine}";
            detalhes += $"Titulo: {filme.Titulo} {Environment.NewLine}";
            detalhes += $"Descrição: {filme.Descricao} {Environment.NewLine}";
            detalhes += $"Lançamento: {filme.Lancamento.ToString("dd/MM/yyyy")} {Environment.NewLine}";
            detalhes += $"Excluido: {(filme.Excluido ? "Sim" : "Não")}";

            Console.WriteLine(detalhes);
        }

        private static void LimparTela() => Console.Clear();

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