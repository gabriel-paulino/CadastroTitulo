using System;
using Titulo.Dominio.Enum;

namespace Titulo.Dominio.Entidades
{
    public class Serie : Base
    {
        public Serie(Guid id, int genero, string titulo, string descricao, DateTime lancamento, int temporadas, int episodios, bool excluido)
        {
            Id = id;
            Genero = (Genero)genero;
            Titulo = titulo;
            Descricao = descricao;
            Lancamento = lancamento;
            Temporadas = temporadas;
            Episodios = episodios;
            Excluido = excluido;
        }

        public Serie(Genero genero, string titulo, string descricao, DateTime lancamento, int temporadas, int episodios)
        {
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Lancamento = lancamento;
            Temporadas = temporadas;
            Episodios = episodios;
            Excluido = false;

            RealizarValidacoes();
        }

        public Genero Genero { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime Lancamento { get; private set; }
        public int Temporadas { get; private set; }
        public int Episodios { get; private set; }
        public bool Excluido { get; private set; }
        
        public void DefinirComoExcluido() => Excluido = true;

        public Serie Editar(
            Genero genero = Genero.NaoInformado,
            string titulo = "",
            string descricao = "",
            DateTime lancamento = new DateTime(),
            int temporadas = 0,
            int episodios = 0)
        {
            _ = genero == Genero.NaoInformado ? Genero : Genero = genero;
            _ = string.IsNullOrEmpty(titulo) ? Titulo : Titulo = titulo;
            _ = string.IsNullOrEmpty(descricao) ? Descricao : Descricao = descricao;
            _ = lancamento == DateTime.MinValue ? Lancamento : Lancamento = lancamento;
            _ = temporadas == 0 ? Temporadas : Temporadas = temporadas;
            _ = episodios == 0 ? Episodios : Episodios = episodios;

            RealizarValidacoes();

            return this;
        }

        public override void RealizarValidacoes() { }
    }
}