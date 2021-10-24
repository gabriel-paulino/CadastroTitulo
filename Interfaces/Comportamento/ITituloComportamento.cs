using CadastroTitulo.Entidades;
using CadastroTitulo.Enum;
using System.Collections.Generic;

namespace CadastroTitulo.Interfaces.Comportamento
{
    public interface ITituloComportamento<T> where T : Base
    {       
        IEnumerable<T> ObterTodos();
        T Obter(int id);
        IEnumerable<T> ObterPorGenero(Genero genero);
        bool Inserir(T titulo);
        T Atualizar(int id, T titulo);
        bool Excluir(int id);
        int ProximoId();
    }
}