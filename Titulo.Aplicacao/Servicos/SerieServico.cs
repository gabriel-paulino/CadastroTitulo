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
        private readonly IUnitOfWork _unitOfWork;

        public SerieServico(
            ISerieRepositorio serieRepositorio,
            IUnitOfWork unitOfWork)
        {
            _serieRepositorio = serieRepositorio;
            _unitOfWork = unitOfWork;
        }

        public bool Atualizar(Serie serieAtualizada)
        {
            _unitOfWork.BeginTransaction();

            bool atualizou = _serieRepositorio.Atualizar(serieAtualizada);

            if (atualizou) 
                _unitOfWork.Commit();
            else
                _unitOfWork.Rollback();

            return atualizou;
        }
            

        public bool Excluir(Guid id) =>
            _serieRepositorio.Excluir(id);

        public bool Inserir(Serie serieNova) =>
            _serieRepositorio.Inserir(serieNova);

        public IEnumerable<Serie> ObterPorGenero(Genero genero) =>
            _serieRepositorio.ObterPorGenero(genero);

        public Serie Obter(Guid id) =>
            _serieRepositorio.Obter(id);

        public IEnumerable<Serie> ObterTodos() =>
            _serieRepositorio.ObterTodos();
    }
}