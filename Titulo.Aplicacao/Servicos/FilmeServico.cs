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

        public Filme Atualizar(Guid id, Filme filmeAtualizado)
        {
            var filme = _filmeRepositorio.Obter(id);

            if (filme is null)
            {
                filmeAtualizado.AdicionarNotificacao("Não existe filme com esse Id");
                return filmeAtualizado;
            }

            filme.Editar(
                genero: filmeAtualizado.Genero,
                titulo: filmeAtualizado.Titulo,
                descricao: filmeAtualizado.Descricao,
                lancamento: filmeAtualizado.Lancamento
                );

            if (!filme.Valido)
                return filme;

            _uow.BeginTransaction();

            if (_filmeRepositorio.Atualizar(filme))
            {
                _uow.Commit();
                return filme;
            }
                
            _uow.Rollback();
            filme.AdicionarNotificacao("Erro ao atualizar filme.");

            return filme;
        }
            

        public bool Excluir(Guid id)
        {
            var filme = _filmeRepositorio.Obter(id);

            if (filme is null)
                return false;

            filme.DefinirComoExcluido();

            _uow.BeginTransaction();

            bool excluiu = _filmeRepositorio.Excluir(id);

            if (excluiu)
                _uow.Commit();
            else
                _uow.Rollback();

            return excluiu;
        }

        public Filme Inserir(Filme filme)
        {
            if (!_filmeRepositorio.Inserir(filme))
                filme.AdicionarNotificacao("Erro ao inserir filme.");

            return filme;
        }
           

        public IEnumerable<Filme> ObterPorGenero(Genero genero) =>
            _filmeRepositorio.ObterPorGenero(genero);

        public Filme Obter(Guid id) =>
            _filmeRepositorio.Obter(id);

        public IEnumerable<Filme> ObterTodos() =>
            _filmeRepositorio.ObterTodos();

        public IEnumerable<Filme> ObterPorTitulo(string titulo) =>
            _filmeRepositorio.ObterPorTitulo(titulo);
    }
}