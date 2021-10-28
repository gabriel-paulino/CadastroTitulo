using Dapper;
using System;
using System.Collections.Generic;
using Titulo.Dominio.Entidades;
using Titulo.Dominio.Enum;
using Titulo.Dominio.Interfaces.Repositorios;
using Titulo.Repositorio.Data;

namespace Titulo.Repositorio.Repositorios
{
    public class SerieRepositorio : ISerieRepositorio
    {
        private readonly DbSession _session;

        public SerieRepositorio(DbSession session)
        {
            _session = session;
        }

        public bool Atualizar(Serie serieAtualizada)
        {
            throw new System.NotImplementedException();
        }

        public bool Excluir(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public bool Inserir(Serie serie)
        {
            throw new System.NotImplementedException();
        }

        public Serie Obter(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Serie> ObterPorGenero(Genero genero)
        {
            throw new System.NotImplementedException();
        }

        public int ObterProximoIdentificador()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Serie> ObterTodos() =>
            _session.Connection.Query<Serie>("SELECT * FROM [Serie]", null, _session.Transaction);
    }
}