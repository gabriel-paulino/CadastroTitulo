using System;
using Titulo.Dominio.Enum;

namespace Titulo.Dominio.Entidades
{
    public class Serie : Base
    {
        public Serie(Genero genero, string titulo, string descricao, DateTime lancamento, int temporadas, int episodios)
        {
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Lancamento = lancamento;
            Temporadas = temporadas;
            Episodios = episodios;
            Excluido = false;
        }

        public Genero Genero { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime Lancamento { get; private set; }
        public int Temporadas { get; private set; }
        public int Episodios { get; private set; }
        public bool Excluido { get; private set; }
        
        public void DefinirComoExcluido() => Excluido = true;
    }
}