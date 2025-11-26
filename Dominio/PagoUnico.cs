namespace Dominio
{
    public class PagoUnico : Pago
    {
        private DateTime _fecha;
        public DateTime Fecha { 
            get { return _fecha; } 
            set { _fecha = value; } 
        }

        public PagoUnico() : base() { }

        public PagoUnico(MetodoPago metodoPago, TipoGasto tipoGasto, Usuario usuario, string descripcion, decimal monto, DateTime fecha) : base(metodoPago, tipoGasto, usuario, descripcion, monto)
        {
            Fecha = fecha;
        }

        public override decimal CalcularMontoTotal()
        {
            decimal montoAjustado = Monto;

            if (MetodoPago == MetodoPago.EFECTIVO)
            {
                // 20% descuento
                montoAjustado *= 0.8m;
            }
            else
            {
                // 10% descuento
                montoAjustado *= 0.9m;
            }

            return montoAjustado;
        }

        public override void Validar()
        {
            base.Validar();
            if (Fecha == DateTime.MinValue)
            {
                throw new Exception("La fecha no puede ser vacía");
            }
        }

    }
}
