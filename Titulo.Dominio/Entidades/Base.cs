using System;
using System.Collections.Generic;
using System.Linq;

namespace Titulo.Dominio.Entidades
{
    public abstract class Base
    {
        protected Base()
        {
            Id = Guid.NewGuid();
            Valido = true;
            _notificacoes = new List<string>();
        }

        private IList<string> _notificacoes;

        public Guid Id { get; protected set; }       
        public IReadOnlyCollection<string> Notificacoes { get => _notificacoes.ToArray(); }
        public bool Valido { get; private set; }
        
        public abstract void RealizarValidacoes();

        public void AdicionarNotificacao(string mensagemErro)
        {
            Valido = false;
            _notificacoes.Add(mensagemErro);
        }

        public string ObterNotificacao()
            => Notificacoes.FirstOrDefault();

        public string ObterNotificacoes() => string.Join(string.Empty, Notificacoes);
    }
}