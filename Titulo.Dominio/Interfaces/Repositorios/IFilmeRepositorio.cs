using System;
using System.Collections.Generic;
using Titulo.Dominio.Entidades;
using Titulo.Dominio.Enum;

namespace Titulo.Dominio.Interfaces.Repositorios
{
    public interface IFilmeRepositorio
    {
        IEnumerable<Filme> ObterTodos();
        IEnumerable<Filme> ObterPorGenero(Genero genero);
        IEnumerable<Filme> ObterPorTitulo(string titulo);
        bool Inserir(Filme filme);
        bool Atualizar(Filme filmeAtualizado);
        bool Excluir(Guid id);
        Filme Obter(Guid id);
    }
}