namespace Dominio
{
    public class PagoRecurrente : Pago
    {

        private DateTime _desde;
        private DateTime _hasta;

        public DateTime Desde
        {
            get { return _desde; }
            set { _desde = value; }
        }
        public DateTime Hasta
        {
            get { return _hasta; }
            set { _hasta = value; }
        }

        public PagoRecurrente(MetodoPago metodoPago, TipoGasto tipoGasto, Usuario usuario, string descripcion, decimal monto, DateTime desde, DateTime hasta) : base(metodoPago, tipoGasto, usuario, descripcion, monto)
        {
            Desde = desde;
            Hasta = hasta;
        }

        public override decimal CalcularMontoTotal(Pago pago)
        {
            if (Desde > Hasta)
            {
                DateTime aux = Desde;
                Desde = Hasta;
                Hasta = aux;
            }
            else
            {
                //calculos
            }

            return 123;

        }

        public override string ToString()
        {
            return base.ToString() + $"---- Cuantos pagos quedan ----";
        }

    }
}
