using System;

namespace Titulo.Dominio.Entidades
{
    public abstract class Base
    {
        protected Base()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }
    }
}