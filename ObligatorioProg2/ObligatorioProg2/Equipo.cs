using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Equipo
    {
        public string Nombre { get; set; }

        static private int s_ultimoID = 0;

        private int _id;
        public int Id
        {
            get { return _id; }
        }
        
        public Equipo(string nombre)
        {
            _id = ++s_ultimoID;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre + " - " + Id;
        }
    }
}
