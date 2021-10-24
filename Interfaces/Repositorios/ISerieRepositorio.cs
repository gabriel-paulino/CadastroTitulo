using CadastroTitulo.Entidades;
using CadastroTitulo.Enum;
using System.Collections.Generic;

namespace CadastroTitulo.Interfaces.Repositorios
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