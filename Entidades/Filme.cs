using CadastroTitulo.Enum;
using System;

namespace CadastroTitulo.Entidades
{
    public class Filme : Base
    {
        public Filme(Genero genero, string titulo, string descricao, DateTime lancamento)
        {
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Lancamento = lancamento;
            Excluido = false;
        }

        public Genero Genero { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime Lancamento { get; private set; }
        public bool Excluido { get; private set; }

        public void DefinirComoExcluido() => Excluido = true;
        
    }
}