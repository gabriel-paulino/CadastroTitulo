using System;
using System.Collections.Generic;
using Titulo.Dominio.Entidades;
using Titulo.Dominio.Enum;

namespace Titulo.Dominio.Interfaces.Repositorios
{
    public interface ISerieRepositorio
    {
        IEnumerable<Serie> ObterTodos();
        IEnumerable<Serie> ObterPorGenero(Genero genero);
        IEnumerable<Serie> ObterPorTitulo(string titulo);
        bool Inserir(Serie serie);
        bool Atualizar(Serie serieAtualizada);
        bool Excluir(Guid id);
        Serie Obter(Guid id);
    }
}