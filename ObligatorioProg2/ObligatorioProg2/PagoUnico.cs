using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PagoUnico : Pago
    {
        private DateTime _fecha;
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }

        public PagoUnico(MetodoPago metodoPago, TipoGasto tipoGasto, Usuario usuario, string descripcion, decimal monto, DateTime fecha)
        {
            this.Id = s_Id++;
            this.MetodoPagoP = metodoPago;
            this.TipoGastoP = tipoGasto;
            this.UsuarioP = usuario;
            this.Descripcion = descripcion;
            this.Monto = monto;
            this.Fecha = fecha;
        }


        public override decimal CalcularMontoTotal(Pago pago)
        {
            return 123;
        }

    }
} 