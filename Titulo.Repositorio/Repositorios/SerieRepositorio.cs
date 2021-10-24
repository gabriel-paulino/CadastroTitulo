using System.Collections.Generic;
using Titulo.Dominio.Entidades;
using Titulo.Dominio.Enum;
using Titulo.Dominio.Interfaces.Repositorios;

namespace Titulo.Repositorio.Repositorios
{
    public class SerieRepositorio : ISerieRepositorio
    {
        public Serie Atualizar(int id, Serie serie)
        {
            throw new System.NotImplementedException();
        }

        public bool Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Inserir(Serie serie)
        {
            throw new System.NotImplementedException();
        }

        public Serie Obter(int id)
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

        public IEnumerable<Serie> ObterTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}