using System.Collections.Generic;
using Titulo.Dominio.Entidades;
using Titulo.Dominio.Enum;
using Titulo.Dominio.Interfaces.Comportamentos;
using Titulo.Dominio.Interfaces.Repositorios;

namespace Aplicacao.Comportamentos
{
    public class SerieComportamento : ITituloComportamento<Serie>
    {
        private readonly ISerieRepositorio _serieRepositorio;

        public SerieComportamento(ISerieRepositorio serieRepositorio)
        {
            _serieRepositorio = serieRepositorio;
        }

        public Serie Atualizar(int id, Serie serie) =>
            _serieRepositorio.Atualizar(id, serie);

        public bool Excluir(int id)
        {
            var Serie = _serieRepositorio.Obter(id);
            Serie.DefinirComoExcluido();

            return Serie.Excluido;
        }

        public bool Inserir(Serie serie)
        {
            serie.DefinirIdentificador(
                _serieRepositorio.ObterProximoIdentificador()
                );

            return _serieRepositorio.Inserir(serie);
        }

        public IEnumerable<Serie> ObterPorGenero(Genero genero) =>
            _serieRepositorio.ObterPorGenero(genero);

        public Serie Obter(int id) =>
            _serieRepositorio.Obter(id);

        public IEnumerable<Serie> ObterTodos() =>
            _serieRepositorio.ObterTodos();
    }
}