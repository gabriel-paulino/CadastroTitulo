using System.Collections.Generic;
using Titulo.Dominio.Entidades;
using Titulo.Dominio.Enum;
using Titulo.Dominio.Interfaces.Comportamentos;
using Titulo.Dominio.Interfaces.Repositorios;

namespace Aplicacao.Comportamentos
{
    public class FilmeComportamento : ITituloComportamento<Filme>
    {
        private readonly IFilmeRepositorio _filmeRepositorio;

        public FilmeComportamento(IFilmeRepositorio filmeRepositorio)
        {
            _filmeRepositorio = filmeRepositorio;
        }

        public Filme Atualizar(int id, Filme filme) => 
            _filmeRepositorio.Atualizar(id, filme);

        public bool Excluir(int id)
        {
            var filme = _filmeRepositorio.Obter(id);
            filme.DefinirComoExcluido();

            return filme.Excluido;
        }

        public bool Inserir(Filme filme)
        {
            filme.DefinirIdentificador(
                _filmeRepositorio.ObterProximoIdentificador()
                );

           return _filmeRepositorio.Inserir(filme);
        }

        public IEnumerable<Filme> ObterPorGenero(Genero genero) => 
            _filmeRepositorio.ObterPorGenero(genero);

        public Filme Obter(int id) =>
            _filmeRepositorio.Obter(id);

        public IEnumerable<Filme> ObterTodos() =>
            _filmeRepositorio.ObterTodos();
    }
}
