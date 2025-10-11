namespace Dominio
{
    public abstract class Pago
    {
        private static int s_id = 0;

        private int _id;
        private MetodoPago _metodoPago;
        private TipoGasto _tipoGasto;
        private Usuario _usuario;
        private string _descripcion;
        private decimal _monto;
        public int s_Id
        {
            get { return s_id; }
            set { s_id = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public MetodoPago MetodoPago
        {
            get { return _metodoPago; }
            set { _metodoPago = value; }
        }
        public TipoGasto TipoGasto
        {
            get { return _tipoGasto; }
            set { _tipoGasto = value; }
        }
        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        public Pago(MetodoPago metodoPago, TipoGasto tipoGasto, Usuario usuario, string descripcion, decimal monto)
        {
            Id = ++s_Id;
            MetodoPago = metodoPago;
            TipoGasto = tipoGasto;
            Usuario = usuario;
            Descripcion = descripcion;
            Monto = monto;
        }

        //ToDo
        public string GetEmailUsuario()
        {
            return this.Usuario.Email;
        }

        public abstract decimal CalcularMontoTotal(Pago pago);

        public override string ToString()
        {
            return $"Pago | {Id} | Método: {MetodoPago} ";
        }

    }


}