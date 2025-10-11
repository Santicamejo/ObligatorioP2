namespace Dominio
{
    public class PagoUnico : Pago
    {
        private DateTime _fecha;
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }

        public PagoUnico(MetodoPago metodoPago, TipoGasto tipoGasto, Usuario usuario, string descripcion, decimal monto, DateTime fecha) : base(metodoPago, tipoGasto, usuario, descripcion, monto)
        {
            Fecha = fecha;
        }


        public override decimal CalcularMontoTotal(Pago pago)
        {
            return 123;
        }
        public override string ToString()
        {
            return base.ToString() + $"Fecha: {Fecha.ToShortDateString()}";
        }

    }
}
