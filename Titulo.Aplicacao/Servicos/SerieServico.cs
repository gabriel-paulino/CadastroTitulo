using System;
using System.Collections.Generic;
using Titulo.Dominio.Entidades;
using Titulo.Dominio.Enum;
using Titulo.Dominio.Interfaces.Repositorios;
using Titulo.Dominio.Interfaces.Servicos;

namespace Aplicacao.Servico
{
    public class SerieServico : ISerieServico
    {
        private readonly ISerieRepositorio _serieRepositorio;
        private readonly IUnitOfWork _uow;

        public SerieServico(
            ISerieRepositorio serieRepositorio,
            IUnitOfWork uow)
        {
            _serieRepositorio = serieRepositorio;
            _uow = uow;
        }

        public Serie Atualizar(Guid id, Serie serieAtualizada)
        {
            var serie = _serieRepositorio.Obter(id);

            if (serie is null)
            {
                serieAtualizada.AdicionarNotificacao("Não existe série com esse Id");
                return serieAtualizada;
            }

            serie.Editar(
                genero: serieAtualizada.Genero,
                titulo: serieAtualizada.Titulo,
                descricao: serieAtualizada.Descricao,
                lancamento: serieAtualizada.Lancamento,
                temporadas: serieAtualizada.Temporadas,
                episodios: serieAtualizada.Episodios
                );

            if (!serie.Valido)
                return serie;

            _uow.BeginTransaction();

            if (_serieRepositorio.Atualizar(serie))
            {
                _uow.Commit();
                return serie;
            }

            _uow.Rollback();
            serie.AdicionarNotificacao("Erro ao atualizar série.");

            return serie;
        }

        public bool Excluir(Guid id)
        {
            var serie = _serieRepositorio.Obter(id);

            if (serie is null)
                return false;

            serie.DefinirComoExcluido();

            _uow.BeginTransaction();

            bool excluiu = _serieRepositorio.Excluir(id);

            if (excluiu)
                _uow.Commit();
            else
                _uow.Rollback();

            return excluiu;
        }

        public Serie Inserir(Serie serie)
        {
            if (!_serieRepositorio.Inserir(serie))
                serie.AdicionarNotificacao("Erro ao inserir série.");

            return serie;
        }

        public IEnumerable<Serie> ObterPorGenero(Genero genero) =>
            _serieRepositorio.ObterPorGenero(genero);

        public Serie Obter(Guid id) =>
            _serieRepositorio.Obter(id);

        public IEnumerable<Serie> ObterTodos() =>
            _serieRepositorio.ObterTodos();

        public IEnumerable<Serie> ObterPorTitulo(string titulo) => 
            _serieRepositorio.ObterPorTitulo(titulo);
    }
}