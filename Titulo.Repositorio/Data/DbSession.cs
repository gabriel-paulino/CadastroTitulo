using System;
using System.Data;
using System.Data.SqlClient;

namespace Titulo.Repositorio.Data
{
    public class DbSession : IDisposable
    {
        private Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession()
        {
            _id = Guid.NewGuid();
            Connection = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=CadastroTitulo;Trusted_Connection=True;");
            Connection.Open();
        }
       public void Dispose() => Connection?.Dispose();
    }
}
