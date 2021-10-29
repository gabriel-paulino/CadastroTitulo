using System;
using System.Collections.Generic;
using Titulo.Dominio.Entidades;
using Titulo.Dominio.Enum;
using Titulo.Dominio.Interfaces.Repositorios;
using Titulo.Dominio.Interfaces.Servicos;

namespace Aplicacao.Servico
{
    public class FilmeServico : IFilmeServico
    {
        private readonly IFilmeRepositorio _filmeRepositorio;
        private readonly IUnitOfWork _uow;

        public FilmeServico(
            IFilmeRepositorio filmeRepositorio,
            IUnitOfWork uow)
        {
            _filmeRepositorio = filmeRepositorio;
            _uow = uow;
        }

        public bool Atualizar(Filme filmeAtualizado) => 
            _filmeRepositorio.Atualizar(filmeAtualizado);

        public bool Excluir(Guid id)
        {
            _uow.BeginTransaction();

            var filme = _filmeRepositorio.Obter(id);
            filme.DefinirComoExcluido();

            bool filmeExcluido = _filmeRepositorio.Excluir(id);

            if (filmeExcluido)
                _uow.Commit();
            else
                _uow.Rollback();

            return filmeExcluido;
        }

        public bool Inserir(Filme filmeNovo) =>
            _filmeRepositorio.Inserir(filmeNovo);

        public IEnumerable<Filme> ObterPorGenero(Genero genero) => 
            _filmeRepositorio.ObterPorGenero(genero);

        public Filme Obter(Guid id) =>
            _filmeRepositorio.Obter(id);

        public IEnumerable<Filme> ObterTodos() =>
            _filmeRepositorio.ObterTodos();
    }
}
