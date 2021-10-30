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
            string command =
                @"
                    UPDATE [Serie] 
                    SET
                        [Genero] = @Genero,
                        [Titulo] = @Titulo,
                        [Descricao] = @Descricao,
                        [Lancamento] = @Lancamento                     
                        [Temporadas] = @Temporadas                     
                        [Episodios] = @Episodios                     
                    WHERE [Id] = @Id
                ";

            int linhasAfetadas = _session.Connection.Execute(command, new
            {
                serieAtualizada.Id,
                Genero = (int)(serieAtualizada.Genero),
                serieAtualizada.Titulo,
                serieAtualizada.Descricao,
                serieAtualizada.Lancamento,
                serieAtualizada.Temporadas,
                serieAtualizada.Episodios,
            },
            _session.Transaction
            );

            return linhasAfetadas == 1;
        }

        public bool Excluir(Guid id)
        {
            string command =
                @"
                    UPDATE [Serie] 
                    SET [Excluido] = 1
                    WHERE [Id] = @Id
                ";

            int linhasAfetadas = _session.Connection.Execute(command, new { Id = id }, _session.Transaction);

            return linhasAfetadas == 1;
        }

        public bool Inserir(Serie serie)
        {
            string command =
                @"
                    INSERT INTO [dbo].[Serie]
                            ([Id], [Genero], [Titulo], [Descricao], [Lancamento], [Temporadas], [Episodios], [Excluido]) 
                    VALUES (@Id, @Genero, @Titulo, @Descricao, @Lancamento, @Temporadas, @Episodios, @Excluido)
                ";

            int linhasAfetadas = _session.Connection.Execute(command, new
            {
                serie.Id,
                Genero = (int)(serie.Genero),
                serie.Titulo,
                serie.Descricao,
                serie.Lancamento,
                serie.Temporadas,
                serie.Episodios,
                serie.Excluido,
            });

            return linhasAfetadas == 1;
        }

        public Serie Obter(Guid id)
        {
            string query = @"
                SELECT
                    [Id],
                    [Genero],
                    [Titulo],
                    [Descricao],
                    [Lancamento],
                    [Temporadas],
                    [Episodios],
                    [Excluido]
                FROM 
                    [Serie]
                WHERE
                    [Id] = @Id
            ";

            return _session.Connection.QuerySingleOrDefault<Serie>(query, new { Id = id });
        }

        public IEnumerable<Serie> ObterPorGenero(Genero genero)
        {
            string query = @"
                SELECT
                    [Id],
                    [Genero],
                    [Titulo],
                    [Descricao],
                    [Lancamento],
                    [Temporadas],
                    [Episodios],
                    [Excluido]
                FROM 
                    [Serie]
                WHERE
                    [Genero] = @Genero
            ";

            return _session.Connection.Query<Serie>(query, new { Genero = (int)genero });
        }

        public IEnumerable<Serie> ObterPorTitulo(string titulo)
        {
            string query = @"
                SELECT
                    [Id],
                    [Genero],
                    [Titulo],
                    [Descricao],
                    [Lancamento],
                    [Temporadas],
                    [Episodios],
                    [Excluido]
                FROM 
                    [Serie]
                WHERE
                    [Titulo] LIKE @Titulo
            ";

            return _session.Connection.Query<Serie>(query, new { Titulo = $"{titulo}%" });
        }

        public IEnumerable<Serie> ObterTodos()
        {
            string query = @"
                SELECT
                    [Id],
                    [Genero],
                    [Titulo],
                    [Descricao],
                    [Lancamento],
                    [Temporadas],
                    [Episodios],
                    [Excluido]
                FROM 
                    [Serie]
            ";

            return _session.Connection.Query<Serie>(query, null);
        }
    }
}