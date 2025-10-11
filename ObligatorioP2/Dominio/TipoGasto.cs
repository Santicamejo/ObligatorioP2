namespace Dominio
{
    public class TipoGasto
    {

        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public TipoGasto(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public override string ToString()
        {
            return $"{Descripcion}";
        }

    }
}