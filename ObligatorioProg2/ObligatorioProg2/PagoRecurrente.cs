using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PagoRecurrente : Pago
    {

        private DateTime _fecha1;
        private DateTime _fecha2;

        public DateTime Fecha1 { 
            get { return _fecha1; } 
            set { _fecha1 = value; } 
        }
        public DateTime Fecha2 { 
            get { return _fecha2; } 
            set { _fecha2 = value; } 
        }

        public PagoRecurrente(MetodoPago metodoPago, TipoGasto tipoGasto, Usuario usuario, string descripcion, decimal monto, DateTime fecha1, DateTime fecha2)
        {
            this.Id = s_Id++;
            this.MetodoPagoP = metodoPago;
            this.TipoGastoP = tipoGasto;
            this.UsuarioP = usuario;
            this.Descripcion = descripcion;
            this.Monto = monto;
            this.Fecha1 = fecha1;
            this.Fecha2 = fecha2;
        }


        public override decimal CalcularMontoTotal(Pago pago)
        {
            if (Fecha1 > Fecha2)
            {
                DateTime aux = Fecha1;
                Fecha1 = Fecha2;
                Fecha2 = aux;
            }
            else
            {
                //calculos
            }

            return 123;

        }

    }
}