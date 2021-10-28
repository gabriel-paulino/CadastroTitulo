using System.Collections.Generic;
using Titulo.Dominio.Enum;
using Titulo.Dominio.Interfaces.Comportamentos;

namespace Titulo.Dominio.Entidades
{
    public class Titulo<T> where T : Base
    {
        public Titulo(ITituloComportamento<T> tituloComportamento)
        {
            TituloComportamento = tituloComportamento;
        }

        public ITituloComportamento<T> TituloComportamento { get; private set; }

        /*
         * ToDo: Pensar em métodos de dominio, estes métodos são de Repository
         * 
        public IEnumerable<T> ObterTodos() => TituloComportamento.ObterTodos();      
        public T ObterPorId(int id) => TituloComportamento.Obter(id);
        public IEnumerable<T> ObterPorGenero(Genero genero) => TituloComportamento.ObterPorGenero(genero);
        public bool Inserir(T titulo) => TituloComportamento.Inserir(titulo);
        public T Atualizar(int id, T titulo) => TituloComportamento.Atualizar(id, titulo);
        public bool Excluir(int id) => TituloComportamento.Excluir(id);
        *
        */
    }
}