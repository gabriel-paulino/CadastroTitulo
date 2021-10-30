using System;
using Titulo.Dominio.Enum;

namespace Titulo.Dominio.Entidades
{
    public class Filme : Base
    {
        public Filme(Guid id, int genero, string titulo, string descricao, DateTime lancamento, bool excluido)
        {
            Id = id;
            Genero = (Genero)genero;
            Titulo = titulo;
            Descricao = descricao;
            Lancamento = lancamento;
            Excluido = excluido;
        }

        public Filme(Genero genero, string titulo, string descricao, DateTime lancamento)
        {
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Lancamento = lancamento;
            Excluido = false;

            RealizarValidacoes();
        }

        public Genero Genero { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime Lancamento { get; private set; }
        public bool Excluido { get; private set; }

        public void DefinirComoExcluido() => Excluido = true;

        public Filme Editar(
            Genero genero = Genero.NaoInformado, 
            string titulo = "", 
            string descricao = "", 
            DateTime lancamento = new DateTime())
        {
            _ = genero == Genero.NaoInformado ? Genero : Genero = genero;
            _ = string.IsNullOrEmpty(titulo) ? Titulo : Titulo = titulo;
            _ = string.IsNullOrEmpty(descricao) ? Descricao : Descricao = descricao;
            _ = lancamento == DateTime.MinValue ? Lancamento : Lancamento = lancamento;

            RealizarValidacoes();

            return this;
        }

        public override void RealizarValidacoes() { }
    }
}