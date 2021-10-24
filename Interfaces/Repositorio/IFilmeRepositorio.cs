using CadastroTitulo.Entidades;
using CadastroTitulo.Enum;
using System.Collections.Generic;

namespace CadastroTitulo.Interfaces.Repositorio
{
    interface IFilmeRepositorio
    {
        IEnumerable<Filme> Listar();
        IEnumerable<Filme> ListarPorGenero(Genero genero);
        bool Inserir(Filme filme);
        Filme Atualizar(int id, Filme filme);
        bool Excluir(int id);
        Filme Visualizar(int id);
    }
}