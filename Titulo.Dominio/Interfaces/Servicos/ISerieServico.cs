using System;
using System.Collections.Generic;
using Titulo.Dominio.Entidades;
using Titulo.Dominio.Enum;

namespace Titulo.Dominio.Interfaces.Servicos
{
    public interface ISerieServico
    {
        IEnumerable<Serie> ObterTodos();
        Serie Obter(Guid id);
        IEnumerable<Serie> ObterPorGenero(Genero genero);
        IEnumerable<Serie> ObterPorTitulo(string titulo);
        Serie Inserir(Serie serie);
        Serie Atualizar(Guid id, Serie serieAtualizado);
        bool Excluir(Guid id);
    }
}