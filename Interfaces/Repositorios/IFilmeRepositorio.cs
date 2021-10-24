using CadastroTitulo.Entidades;
using CadastroTitulo.Enum;
using System.Collections.Generic;

namespace CadastroTitulo.Interfaces.Repositorios
{
    public interface IFilmeRepositorio
    {
        IEnumerable<Filme> ObterTodos();
        IEnumerable<Filme> ObterPorGenero(Genero genero);
        bool Inserir(Filme filme);
        Filme Atualizar(int id, Filme filme);
        bool Excluir(int id);
        Filme Obter(int id);
        int ObterProximoIdentificador();
    }
}