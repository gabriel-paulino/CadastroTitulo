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
        IEnumerable<Filme> ObterPorTitulo(string titulo);
        Filme Inserir(Filme filme);
        Filme Atualizar(Guid id, Filme filmeAtualizado);
        bool Excluir(Guid id);
    }
}