namespace Dominio
{
    public class Sistema
    {

        private List<Usuario> _usuarios;
        private List<Equipo> _equipos;
        private List<Pago> _pagos;
        private List<TipoGasto> _tipoGastos;

        private static Sistema s_instancia;

        #region Singleton

        public static Sistema Instancia
        {
            get
            {
                if (s_instancia == null) s_instancia = new Sistema();
                return s_instancia;
            }
        }

        private Sistema()
        {
            _usuarios = new List<Usuario>();
            _equipos = new List<Equipo>();
            _pagos = new List<Pago>();
            _tipoGastos = new List<TipoGasto>();

            Precargar();
        }

        #endregion

        public void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1- Mostrar listado de todos los usuarios");
            Console.WriteLine("2- Mostrar pagos del usuario (por email)");
            Console.WriteLine("3- Alta de usuario");
            Console.WriteLine("4- Mostrar integrantes de equipo (por nombre)");
            Console.WriteLine("0- Salir");
            Console.WriteLine();
        }

        public int Opcion()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int opcion))
                {
                    if (opcion >= 0 || opcion <= 4)
                    {
                        return opcion;
                    }
                    else
                    {
                        Console.WriteLine("No existe esa opcion");
                    }
                }
                else
                {
                    Console.WriteLine("Se debe ingrear un numero");
                }
            }

        }

        private void Precargar()
        {

            // ---- EQUIPOS ----
            Equipo e1 = new Equipo("Equipo Administrativo");
            Equipo e2 = new Equipo("Equipo Soporte");
            Equipo e3 = new Equipo("Equipo Interfaz");
            Equipo e4 = new Equipo("Equipo Limpieza");

            AgregarEquipo(e1);
            AgregarEquipo(e2);
            AgregarEquipo(e3);
            AgregarEquipo(e4);


            // ---- USUARIOS ----
            Usuario u1 = new Usuario("Santiago", "Miranda", "sm116805", e1, new DateTime(2002, 10, 02));
            Usuario u2 = new Usuario("Bruno", "Silva", "Brun0_S1lva", e2, new DateTime(2022, 11, 2));
            Usuario u3 = new Usuario("Camila", "Fernández" , "Cam1_R0dri!", e3, new DateTime(2024, 7, 1));
            Usuario u4 = new Usuario("Diego", "Fernández", "Df_2024x8", e1, new DateTime(2021, 5, 10));
            Usuario u5 = new Usuario("Ana", "Pérez", "AnaP3rez_2025", e4, new DateTime(2025, 1, 5));             
            Usuario u6 = new Usuario("Bruno", "Silva", "BrunoSilva#02", e3, new DateTime(2020, 9, 28));       
            Usuario u7 = new Usuario("Sofía", "Domínguez", "Sofi_D0m", e2, new DateTime(2019, 12, 5));
            Usuario u8 = new Usuario("Sofia", "Domínguez", "Sofi@Caps", e2, new DateTime(2019, 12, 5));   
            Usuario u9 = new Usuario("Valentina", "Alvarez", "VAlv#2024", e3, new DateTime(2024, 2, 20));
            Usuario u10 = new Usuario("Valentina", "Alvarez", "Val_Alv_24", e3, new DateTime(2024, 2, 20));
            Usuario u11 = new Usuario("Valentina", "Alvarez", "Val_Alv_24", e3, new DateTime(2024, 2, 20));

            AgregarUsuario(u1);
            AgregarUsuario(u2); 
            AgregarUsuario(u3); 
            AgregarUsuario(u4); 
            AgregarUsuario(u5); 
            AgregarUsuario(u6);
            AgregarUsuario(u7); 
            AgregarUsuario(u8); 
            AgregarUsuario(u9); 
            AgregarUsuario(u10);
            AgregarUsuario(u11);
        }

        public void AgregarEquipo(Equipo nuevoEquipo)
        {
            _equipos.Add(nuevoEquipo);
        }

        public void AgregarGasto(TipoGasto nuevoGasto) //ToDo
        {
        }

        public void AgregarPago(Pago nuevoPago) //ToDo
        {
        }

        //Creo el metodo AgrgearUsuario para 1 delegar responsabilidades y 2 para poder generar el usuario
        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            //Creo el email en este metodo para al precargar Usuarios se les genere el email y valide si ya existe otro con el mismo
            nuevoUsuario.Email = GenerarEmail(nuevoUsuario.Nombre, nuevoUsuario.Apellido); ;
            _usuarios.Add(nuevoUsuario);
        }

        public void AltaUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR NUEVO USUARIO ===\n");

            Console.WriteLine("Ingresar nombre");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingresar apellido");
            string apellido = Console.ReadLine();

            Console.WriteLine("Crear una contraseña de mínimo 8 carácteres");
            string password = Console.ReadLine();

            // pruebas
            Equipo equipo = new Equipo("Equipo IT");
            DateTime trabajaDesde = DateTime.Now;

            //no le paso por parametros el email, ya que se auto-genera
            Usuario nuevoUsuario = new Usuario(nombre, apellido, password, equipo, trabajaDesde);

            try
            {
                nuevoUsuario.Validar();
                AgregarUsuario(nuevoUsuario);
                Console.WriteLine("\n=== USUARIO CREADO CON ÉXITO ===");
            }
            catch(Exception unaE)
            {
                Console.WriteLine(unaE.Message);
            }
        }

        public List<Equipo> GetEquipos()
        {
            List<Equipo> listado = new List<Equipo>();
            foreach(Equipo unE in _equipos)
            {
                listado.Add(unE);
            }
            return listado;
        }
 
        public List<Usuario> GetUsuarios()
        {
            return new List<Usuario>(_usuarios);
        }




        public string GenerarEmail(string nombre, string apellido)
        {
            string nombreCortado = nombre.Substring(0, Math.Min(3, nombre.Length)).ToLower();
            string apellidoCortado = apellido.Substring(0, Math.Min(3, apellido.Length)).ToLower();
            string nombreDeUsuario = nombreCortado + apellidoCortado;

            string extension = "@laempresa.com";

            string emailCreado = nombreDeUsuario + extension;

            int contador = 0;
            bool existe = new bool();

            do
            {
                foreach (Usuario unU in _usuarios)
                {
                    if (unU.Email == emailCreado)
                    {
                        existe = true;
                        contador++;
                        emailCreado = nombreDeUsuario + contador + extension;
                    }
                    else
                    {
                        existe=false;
                    }
                }
            } while (existe);
            return emailCreado;
        }




    }
}
