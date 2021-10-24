using System.Collections.Generic;
using Titulo.Dominio.Entidades;
using Titulo.Dominio.Enum;

namespace Titulo.Dominio.Interfaces.Comportamentos
{
    public interface ITituloComportamento<T> where T : Base
    {       
        IEnumerable<T> ObterTodos();
        T Obter(int id);
        IEnumerable<T> ObterPorGenero(Genero genero);
        bool Inserir(T titulo);
        T Atualizar(int id, T titulo);
        bool Excluir(int id);
    }
}