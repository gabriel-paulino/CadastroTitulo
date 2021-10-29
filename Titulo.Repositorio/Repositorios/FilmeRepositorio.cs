using Dapper;
using System;
using System.Collections.Generic;
using Titulo.Dominio.Entidades;
using Titulo.Dominio.Enum;
using Titulo.Dominio.Interfaces.Repositorios;
using Titulo.Repositorio.Data;

namespace Titulo.Repositorio.Repositorios
{
    public class FilmeRepositorio : IFilmeRepositorio
    {
        private readonly DbSession _session;

        public FilmeRepositorio(DbSession session) => _session = session;

        public bool Atualizar(Filme filmeAtualizado)
        {
            string command =
                @"
                    UPDATE [Filme] 
                    SET
                        [Genero] = @Genero,
                        [Titulo] = @Titulo,
                        [Descricao] = @Descricao,
                        [Lancamento] = @Lancamento                     
                    WHERE [Id] = @Id
                ";

            int linhasAfetadas = _session.Connection.Execute(command, new
            {
                filmeAtualizado.Id,
                Genero = (int)(filmeAtualizado.Genero),
                filmeAtualizado.Titulo,
                filmeAtualizado.Descricao,
                filmeAtualizado.Lancamento,
            });

            return linhasAfetadas == 1;
        }

        public bool Excluir(Guid id)
        {
            string command = 
                @"
                    UPDATE [Filme] 
                    SET [Excluido] = 1
                    WHERE [Id] = @Id
                ";

            int linhasAfetadas = _session.Connection.Execute(command, new { Id = id}, _session.Transaction);

            return linhasAfetadas == 1;
        }

        public bool Inserir(Filme filme)
        {
            string command = 
                @"
                    INSERT INTO [dbo].[Filme]
                            ([Id], [Genero], [Titulo], [Descricao], [Lancamento], [Excluido]) 
                    VALUES (@Id, @Genero, @Titulo, @Descricao, @Lancamento, @Excluido)
                ";

            int linhasAfetadas = _session.Connection.Execute(command, new
            {
                filme.Id,
                Genero = (int)(filme.Genero),
                filme.Titulo,
                filme.Descricao,
                filme.Lancamento,
                filme.Excluido,
            });

            return linhasAfetadas == 1;
        }

        public Filme Obter(Guid id)
        {
            string query = @"
                SELECT
                    [Id],
                    [Genero],
                    [Titulo],
                    [Descricao],
                    [Lancamento],
                    [Excluido]
                FROM 
                    [Filme]
                WHERE
                    [Id] = @Id
            ";

            return _session.Connection.QuerySingleOrDefault<Filme>(query, new {Id = id }, _session.Transaction);
        }

        public IEnumerable<Filme> ObterPorGenero(Genero genero)
        {
            string query = @"
                SELECT
                    [Id],
                    [Genero],
                    [Titulo],
                    [Descricao],
                    [Lancamento],
                    [Excluido]
                FROM 
                    [Filme]
                WHERE
                    [Genero] = @Genero
            ";

            return _session.Connection.Query<Filme>(query, new { Genero = (int)genero }, _session.Transaction);
        }

        public IEnumerable<Filme> ObterTodos()
        {
            string query = @"
                SELECT
                    [Id],
                    [Genero],
                    [Titulo],
                    [Descricao],
                    [Lancamento],
                    [Excluido]
                FROM 
                    [Filme]
            ";

            return _session.Connection.Query<Filme>(query, null, _session.Transaction);
        }
    }
}