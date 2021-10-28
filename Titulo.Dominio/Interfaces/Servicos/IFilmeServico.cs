using System;
using System.Collections.Generic;
using Titulo.Dominio.Entidades;
using Titulo.Dominio.Enum;

namespace Titulo.Dominio.Interfaces.Servicos
{
    public interface IFilmeServico
    {
        IEnumerable<Filme> ObterTodos();
        Filme Obter(Guid id);
        IEnumerable<Filme> ObterPorGenero(Genero genero);
        bool Inserir(Filme filmeNovo);
        bool Atualizar(Filme filmeAtualizado);
        bool Excluir(Guid id);
    }
}