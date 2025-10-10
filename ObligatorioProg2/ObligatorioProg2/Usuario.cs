using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Dominio
{
    public class Usuario
    {

        private string _nombre;
        private string _apellido;
        private string _email;
        private string _contrasenia;
        private Equipo _equipo;
        private DateTime _empleadoDesde;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Contrasenia
        {
            get { return _contrasenia; }
            set { _contrasenia = value; }
        }
        public Equipo Equipo
        {
            get { return _equipo; }
            set { _equipo = value; }
        }
        public DateTime EmpleadoDesde
        {
            get { return _empleadoDesde; }
            set { _empleadoDesde = value; }
        }

        public Usuario(string nombre, string apellido, string email, string contrasenia, Equipo equipo, DateTime emdesde) 
        {   
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
            this.Contrasenia = contrasenia;
            this.Equipo = equipo;
            this.EmpleadoDesde = emdesde;
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new Exception("El nombre no puede ser vacío.");

            if (string.IsNullOrWhiteSpace(Apellido))
                throw new Exception("El apellido no puede ser vacío.");

            if (string.IsNullOrWhiteSpace(Contrasenia))
                throw new Exception("La contraseña no puede ser vacía.");

            if (Contrasenia.Length < 8)
                throw new Exception("La contraseña debe tener 8 dígitos o más.");
        }

        public override string ToString()
        {
            return $"{Nombre} - {Email} - {Equipo}";
        }

    }
}
