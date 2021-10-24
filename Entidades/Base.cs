namespace CadastroTitulo.Entidades
{
    public abstract class Base
    {
        public int Id { get; protected set; }

        public void DefinirIdentificador(int id) => Id = id;
    }
}