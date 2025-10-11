using Dominio;

namespace ObligatorioP2
{
    internal class Program
    {
        private static Sistema sistema = Sistema.Instancia;

        static void Main(string[] args)
        {
            sistema.Menu();
            int opcion = sistema.Opcion();

            while (opcion != 0)
            {
                switch (opcion)
                {
                    case 1:
                        Cargando();
                        MostrarUsuarios();
                        Continuar();
                        break;
                    case 2:
                        Cargando();
                        MostrarPagos();
                        Continuar();
                        break;
                    case 3:
                        Cargando();
                        CrearUsuario(); ;
                        Continuar();
                        break;
                    case 4:
                        Cargando();
                        MostrarIntegrantesEquipo();
                        Continuar();
                        break;
                }
             
                sistema.Menu();
                opcion = sistema.Opcion();

            }
        }

        private static void CrearUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR NUEVO USUARIO ===\n");

            Console.WriteLine("Ingresar nombre");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingresar apellido");
            string apellido = Console.ReadLine();

            Console.WriteLine("Crear una contraseña de mínimo 8 carácteres");
            string password = Console.ReadLine();

            // pruebas ToDO
            Console.WriteLine("Ingresar nombre de equipo");
            string equipoIngresado = Console.ReadLine();
            Equipo equipo = null;

            foreach (Equipo unE in sistema.GetEquipos())
            {
                if (unE.Nombre.ToLower() == equipoIngresado.ToLower())
                    equipo = unE;
            }

            Console.WriteLine("Ingresr fecha de ingreso a la empresa (YYYY-MM-DD)");

            DateTime trabajaDesde = new DateTime();
            if (DateTime.TryParse(Console.ReadLine(), out trabajaDesde))
            {
                //no le paso por parametros el email, ya que se autogenera
                Usuario nuevoUsuario = new Usuario(nombre, apellido, password, equipo, trabajaDesde);
                sistema.AltaUsuario(nuevoUsuario);
            }
            else
            {
                Console.WriteLine("La fecha no puede estar vacia y debe ester en formato YYYY-MM-DD");
            }
        }

        private static void MostrarUsuarios()
        {
            Console.Clear();
            Console.WriteLine("=== USUARIOS ===");

            List<Usuario> usuarios = sistema.GetUsuarios();

            if (usuarios.Count > 0)
            {
                foreach (Usuario unU in usuarios)
                    Console.WriteLine(unU.ToString() + "\n");
            }
            else
            {
                Console.WriteLine("No existen usuarios en el sistema");
            }
        }

        private static void MostrarPagos()
        {
            Console.Clear();
            Console.WriteLine("Ingresa un Email:");
            string EmailIngresado = Console.ReadLine();

            List<Pago> pagosCliente = sistema.GetPagos(EmailIngresado);

            if (EmailIngresado == null || EmailIngresado == "")
            {
                Console.WriteLine($"Se debe ingresar un Email");
            }
            else
            {
                Console.WriteLine("\n=== PAGOS ===");
                if (pagosCliente.Count > 0)
                {
                    foreach (Pago unU in pagosCliente)
                        Console.WriteLine(unU.ToString() + "\n");
                }
                else
                {
                    Console.WriteLine($"No existen pagos para el usuario {EmailIngresado} en el sistema");
                }
            }

        }


        private static void MostrarIntegrantesEquipo()
        {
            Console.WriteLine("=== EQUIPOS REGISTRADOS ===");
            foreach (Equipo unE in sistema.GetEquipos())
            {
                Console.WriteLine(unE.Nombre);
            }

            Console.WriteLine("Ingrese el nombre de equipo: ");
            string nombreIngresado = Console.ReadLine();

            bool existeEquipo = false;
            foreach (Equipo unE in sistema.GetEquipos())
            {
                if (unE.Nombre.ToLower() == nombreIngresado.ToLower())
                    existeEquipo = true;
            }

            if (existeEquipo)
            {
                List<Usuario> usuariosE = new List<Usuario>();
                foreach (Usuario unU in sistema.GetUsuarios())
                {
                    if (unU.Equipo.Nombre.ToLower() == nombreIngresado.ToLower())
                        usuariosE.Add(unU);

                }

                if (usuariosE.Count > 0)
                {
                    Console.WriteLine("\n");
                    foreach (Usuario unU in usuariosE)
                        Console.WriteLine(unU.Nombre + unU.Email);
                }
                else
                {
                    Console.WriteLine("El equipo no tiene integrantes.");
                }
            }
            else { Console.WriteLine("\n El equipo ingresado no existe"); }

        }


        //Funciones

        private static void Continuar()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Cargando(int milisegundos = 1000)
        {
            string frames = "|/-\\";
            for (int i = 0; i < milisegundos / 100; i++)
            {
                Console.Write("\rCargando " + frames[i % frames.Length]);
                Thread.Sleep(100);
            }
            Console.Write("\rListo!        \n");
        }


        

    }
}
