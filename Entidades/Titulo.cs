using CadastroTitulo.Enum;
using CadastroTitulo.Interfaces.Comportamentos;
using System.Collections.Generic;

namespace CadastroTitulo.Entidades
{
    public class Titulo<T> where T : Base
    {
        public Titulo(ITituloComportamento<T> tituloComportamento)
        {
            TituloComportamento = tituloComportamento;
        }

        public ITituloComportamento<T> TituloComportamento { get; private set; }

        public IEnumerable<T> ObterTodos() => TituloComportamento.ObterTodos();      
        public T ObterPorId(int id) => TituloComportamento.Obter(id);
        public IEnumerable<T> ObterPorGenero(Genero genero) => TituloComportamento.ObterPorGenero(genero);
        public bool Inserir(T titulo) => TituloComportamento.Inserir(titulo);
        public T Atualizar(int id, T titulo) => TituloComportamento.Atualizar(id, titulo);
        public bool Excluir(int id) => TituloComportamento.Excluir(id);
    }
}