using System;

namespace Titulo.Dominio.Interfaces.Repositorios
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}