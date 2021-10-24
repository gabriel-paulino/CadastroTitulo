using System.Collections.Generic;
using Titulo.Dominio.Entidades;
using Titulo.Dominio.Enum;

namespace Titulo.Dominio.Interfaces.Repositorios
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