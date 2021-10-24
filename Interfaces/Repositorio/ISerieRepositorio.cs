using CadastroTitulo.Entidades;
using CadastroTitulo.Enum;
using System.Collections.Generic;

namespace CadastroTitulo.Interfaces.Repositorio
{
    public interface ISerieRepositorio
    {
        IEnumerable<Serie> Listar();
        IEnumerable<Serie> ListarPorGenero(Genero genero);
        bool Inserir(Serie serie);
        bool Atualizar();
        bool Excluir(int id);
        Serie Visualizar(int id);
    }
}