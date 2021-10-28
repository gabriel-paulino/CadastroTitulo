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
        bool Inserir(Serie serieNova);
        bool Atualizar(Serie serieAtualizado);
        bool Excluir(Guid id);
    }
}