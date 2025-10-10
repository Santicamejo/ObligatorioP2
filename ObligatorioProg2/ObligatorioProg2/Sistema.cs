using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios;
        private List<Equipo> _equipos;
        private List<Pago> _pagos;
        private List<TipoGasto> _tipoGastos;

        private static Sistema s_instancia;

        private Sistema() 
        {
            _usuarios = new List<Usuario>();
            _equipos = new List<Equipo>();
            _pagos = new List<Pago>();
            _tipoGastos = new List<TipoGasto>();

            Precargar();
        }

        public static Sistema Instancia
        {
            get { if (s_instancia == null) s_instancia = new Sistema();
                return s_instancia;
            }
        }

        public void Menu()
        {
            Console.Clear();

            Console.WriteLine("- MENU -\n\n" +
                "1- Mostrar listado de todos los usuarios\n" +
                "2- Mostrar pagos del usuario dado email\n" +
                "3- Alta de usuario\n" +
                "4- Mostrar integrantes de equipo dado nombre de equipo\n" +
                "0- Salir\n");
        }

        public int IngresoOpcion()
        {
            int opcion;
            bool novalido;

            do
            {
                Console.WriteLine("Ingrese opción: ");
                novalido = int.TryParse(Console.ReadLine(), out opcion);
                if (opcion < 0 || opcion > 4)
                {
                    Menu();
                    Console.WriteLine("Opción inválida.");
                }
            }
            
            while ((opcion < 0) || (opcion > 4));
            return opcion;
        }

        public void AltaUsuario()
        {

            Console.Clear();
            Console.WriteLine("- REGISTRAR USUARIO -");

            Console.WriteLine("\nIngresar nombre: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingresar apellido: ");
            string apellido = Console.ReadLine();

            string email = GenerarMail(nombre, apellido);

            Console.Write("Ingresar contraseña (mínimo 8 carácteres): ");
            string contrasenia = Console.ReadLine();

            // esto es solo pa debuggear hajaj
            Equipo equipo = new Equipo("Equipo IT");
            DateTime fechashit = DateTime.Now;

            Usuario nuevoUsuario = new Usuario(nombre, apellido, email, contrasenia, equipo, fechashit);
            try { 
                nuevoUsuario.Validar();
                _usuarios.Add(nuevoUsuario);
                Console.WriteLine("Usuario creado con éxito.");
                Console.Read();
                }

            catch(Exception ex) 
                { 
                Console.WriteLine(ex.Message);
                Console.Read();
                }

        }

        public void Precargar()
        {
            Equipo equipo1 = new Equipo("Equipo IT");
            Equipo equipo2 = new Equipo("Equipo Desarrollo");
            Equipo equipo3 = new Equipo("Equipo Locura");
            Equipo equipo4 = new Equipo("Equipo Nada");

            _equipos.Add(equipo1);
            _equipos.Add(equipo2);
            _equipos.Add(equipo3);
            _equipos.Add(equipo4);
        }

        public void MostrarEquipos()
        {
            if (_equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos cargados.");
                return;
            }

            Console.WriteLine("=== Equipos ===");
            foreach (Equipo e in _equipos)
                Console.WriteLine(e);
        }

        public void MostrarUsuarios()
        {
            List<Usuario> listado = new List<Usuario>(_usuarios);
            foreach(Usuario unU in listado)
            {
                Console.WriteLine(unU.ToString());
            }
        }

        public string GenerarMail(string nombre, string apellido)
        {
            /*
            string primer = nom.Substring(0, 3).ToLower();
            ^^^^^^^ escribiendolo asi si se ungresa un nombre o ape menor que 3 salta una exception
            xq no existiria el index 3 en ese string,

            --------------------------------------------------------------------------------------------------

            con esta forma evalua y toma el menor de 3 o el Length del string, y si el Length es el menor
            ese pasa a ser el index del substring y lo agarra entero
            */
            string nombreCortado = nombre.Substring(0, Math.Min(3, nombre.Length)).ToLower();
            string apellidoCortado = apellido.Substring(0, Math.Min(3, apellido.Length)).ToLower();

            string email = nombreCortado + apellidoCortado;
            string extencion = "@laEmpresa.com";

            int contador = 1;

            // si el mail coincide con el mail de algun usuario de la lista de usus se le suma el 
            // cont al final
            while (_usuarios.Any(u => u.Email == email))
            {
                email = email + contador + extencion;
                contador++;
            }

            return email;
        }


        
    }
}
