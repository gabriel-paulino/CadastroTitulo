using System.Collections.Generic;
using Titulo.Dominio.Entidades;
using Titulo.Dominio.Enum;

namespace Titulo.Dominio.Interfaces.Repositorios
{
    public interface ISerieRepositorio
    {
        IEnumerable<Serie> ObterTodos();
        IEnumerable<Serie> ObterPorGenero(Genero genero);
        bool Inserir(Serie serie);
        Serie Atualizar(int id, Serie serie);
        bool Excluir(int id);
        Serie Obter(int id);
        int ObterProximoIdentificador();
    }
}