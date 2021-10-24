using System.Collections.Generic;
using Titulo.Dominio.Entidades;
using Titulo.Dominio.Enum;
using Titulo.Dominio.Interfaces.Repositorios;

namespace Titulo.Repositorio.Repositorios
{
    public class FilmeRepositorio : IFilmeRepositorio
    {
        public Filme Atualizar(int id, Filme filme)
        {
            throw new System.NotImplementedException();
        }

        public bool Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Inserir(Filme filme)
        {
            throw new System.NotImplementedException();
        }

        public Filme Obter(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Filme> ObterPorGenero(Genero genero)
        {
            throw new System.NotImplementedException();
        }

        public int ObterProximoIdentificador()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Filme> ObterTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}