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
            Console.WriteLine("2- Mostrar pagos del usuario(por email)");
            Console.WriteLine("3- Alta de usuario");
            Console.WriteLine("4- Mostrar integrantes por nombre de equipo");
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
                    if (opcion >= 0 && opcion <= 4)
                    {
                        return opcion;
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un numero del rango 1-4");
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
            Equipo e1 = new Equipo("Administrativo");
            Equipo e2 = new Equipo("Soporte");
            Equipo e3 = new Equipo("Interfaz");
            Equipo e4 = new Equipo("Limpieza");

            AgregarEquipo(e1);
            AgregarEquipo(e2);
            AgregarEquipo(e3);
            AgregarEquipo(e4);


            // ---- USUARIOS ----
            Usuario u1 = new Usuario("Santiago", "Miranda", "sm116805", e1, new DateTime(2002, 10, 02));
            Usuario u2 = new Usuario("Bruno", "Silva", "Brun0_S1lva", e2, new DateTime(2022, 11, 2));
            Usuario u3 = new Usuario("Camila", "Fernández", "Cam1_R0dri!", e3, new DateTime(2024, 7, 1));
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


            TipoGasto g1 = new TipoGasto("g1", "Insumos y materiales");
            TipoGasto g2 = new TipoGasto("g2", "Traslados y movilidad");
            TipoGasto g3 = new TipoGasto("g3", "Alimentación y refrigerios");
            TipoGasto g4 = new TipoGasto("g4", "Mantenimiento y reparaciones");
            TipoGasto g5 = new TipoGasto("g5", "Papelería e impresiones");
            TipoGasto g6 = new TipoGasto("g6", "Servicios de internet");
            TipoGasto g7 = new TipoGasto("g7", "Almacenamiento en la nube");
            TipoGasto g8 = new TipoGasto("g8", "Software y licencias");
            TipoGasto g9 = new TipoGasto("g9", "Equipamiento audiovisual");
            TipoGasto g10 = new TipoGasto("g10", "Peajes y estacionamiento");
            TipoGasto g11 = new TipoGasto("g11", "Limpieza e higiene");
            TipoGasto g12 = new TipoGasto("g12", "Publicidad y difusión");
            TipoGasto g13 = new TipoGasto("g13", "Seguros y garantías");
            TipoGasto g14 = new TipoGasto("g14", "Capacitación y cursos");
            TipoGasto g15 = new TipoGasto("g15", "Servicios profesionales/tercerizados");

            AgregarGasto(g1);
            AgregarGasto(g2);
            AgregarGasto(g3);
            AgregarGasto(g4);
            AgregarGasto(g5);
            AgregarGasto(g6);
            AgregarGasto(g7);
            AgregarGasto(g8);
            AgregarGasto(g9);
            AgregarGasto(g10);
            AgregarGasto(g11);
            AgregarGasto(g12);
            AgregarGasto(g13);
            AgregarGasto(g14);
            AgregarGasto(g15);

            // ===== PAGOS ÚNICOS =====
            Pago p1 = new PagoUnico(MetodoPago.EFECTIVO, g1, u1, "Compra de insumos", 1250m, new DateTime(2024, 10, 16));
            Pago p2 = new PagoUnico(MetodoPago.CREDITO, g9, u3, "Reposición de micrófono", 8900m, new DateTime(2025, 2, 3));
            Pago p3 = new PagoUnico(MetodoPago.DEBITO, g2, u2, "Traslados actividad escuelas", 1850m, new DateTime(2025, 3, 12));
            Pago p4 = new PagoUnico(MetodoPago.EFECTIVO, g3, u4, "Refrigerio jornada talleres", 970m, new DateTime(2025, 4, 7));
            Pago p5 = new PagoUnico(MetodoPago.CREDITO, g8, u6, "Licencia de edición (pago único)", 2490m, new DateTime(2025, 1, 15));
            Pago p7 = new PagoUnico(MetodoPago.DEBITO, g5, u5, "Papelería e impresiones", 1390m, new DateTime(2025, 2, 20));
            Pago p8 = new PagoUnico(MetodoPago.EFECTIVO, g10, u10, "Peajes y estacionamiento", 420m, new DateTime(2025, 6, 2));
            Pago p9 = new PagoUnico(MetodoPago.CREDITO, g4, u7, "Mantenimiento de cámaras", 5200m, new DateTime(2025, 5, 10));
            Pago p10 = new PagoUnico(MetodoPago.DEBITO, g11, u9, "Servicio de limpieza evento", 1600m, new DateTime(2025, 3, 28));
            Pago p11 = new PagoUnico(MetodoPago.CREDITO, g13, u2, "Seguro equipos (franquicia)", 3200m, new DateTime(2025, 7, 4));
            Pago p12 = new PagoUnico(MetodoPago.EFECTIVO, g14, u11, "Capacitación breve (taller)", 2100m, new DateTime(2025, 8, 22));

            // ===== PAGOS RECURRENTES =====
            Pago p6 = new PagoRecurrente(MetodoPago.DEBITO, g12, u8, "Servicio de internet (sede)", 2100m, new DateTime(2025, 8, 1), new DateTime(2025, 12, 31));
            Pago p13 = new PagoRecurrente(MetodoPago.CREDITO, g7, u6, "Almacenamiento nube (mensual)", 999m, new DateTime(2025, 1, 1), new DateTime(2025, 12, 31));
            Pago p14 = new PagoRecurrente(MetodoPago.CREDITO, g8, u7, "Suite de edición (mensual)", 2490m, new DateTime(2025, 1, 15), new DateTime(2025, 12, 15));
            Pago p15 = new PagoRecurrente(MetodoPago.DEBITO, g2, u8, "Movilidad semanal actividades", 1200m, new DateTime(2025, 9, 1), new DateTime(2025, 11, 30));
            Pago p16 = new PagoRecurrente(MetodoPago.CREDITO, g10, u9, "Estacionamiento mensual", 750m, new DateTime(2025, 3, 1), new DateTime(2025, 12, 31));
            Pago p17 = new PagoRecurrente(MetodoPago.DEBITO, g3, u10, "Catering talleres (mensual)", 3100m, new DateTime(2025, 7, 1), new DateTime(2025, 10, 31));
            Pago p18 = new PagoRecurrente(MetodoPago.CREDITO, g1, u1, "Reposición insumos (bimensual)", 4600m, new DateTime(2025, 2, 5), new DateTime(2025, 8, 31));
            Pago p19 = new PagoRecurrente(MetodoPago.DEBITO, g12, u3, "Publicidad y difusión (mensual)", 1800m, new DateTime(2025, 6, 1), new DateTime(2025, 12, 31));
            Pago p20 = new PagoRecurrente(MetodoPago.CREDITO, g13, u4, "Seguro integral anual", 12500m, new DateTime(2025, 1, 1), new DateTime(2025, 12, 31));

            AgregarPago(p1);
            AgregarPago(p2);
            AgregarPago(p3);
            AgregarPago(p4);
            AgregarPago(p5);
            AgregarPago(p7);
            AgregarPago(p8);
            AgregarPago(p9);
            AgregarPago(p10);
            AgregarPago(p11);
            AgregarPago(p12);
            AgregarPago(p6);
            AgregarPago(p13);
            AgregarPago(p14);
            AgregarPago(p15);
            AgregarPago(p16);
            AgregarPago(p17);
            AgregarPago(p18);
            AgregarPago(p19);
            AgregarPago(p20);

        }

        public void AgregarEquipo(Equipo nuevoEquipo)
        {
            _equipos.Add(nuevoEquipo);
        }

        public void AgregarGasto(TipoGasto nuevoGasto)
        {
            _tipoGastos.Add(nuevoGasto);
        }

        public void AgregarPago(Pago nuevoPago)
        {
            _pagos.Add(nuevoPago);
        }

        //Creo el metodo AgrgearUsuario para 1 delegar responsabilidades y 2 para poder generar el usuario
        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            //Creo el email en este metodo para al precargar Usuarios se les genere el email y valide si ya existe otro con el mismo
            nuevoUsuario.Email = GenerarEmail(nuevoUsuario.Nombre, nuevoUsuario.Apellido);
            _usuarios.Add(nuevoUsuario);
        }

        public void AltaUsuario(Usuario usuarioNuevo)
        {
            try
            {
                usuarioNuevo.Validar();
                AgregarUsuario(usuarioNuevo);
                Console.WriteLine("\n=== USUARIO CREADO CON ÉXITO ===");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //No se usa
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
            //Esto devuelve una copia de la lista original 
            return new List<Usuario>(_usuarios);
        }

        public List<Pago> GetPagos(string EmailIngresado)
        {
            List<Pago> listado = new List<Pago>();
            foreach (Pago unP in _pagos)
            {
                if(unP.GetEmailUsuario().ToLower() == EmailIngresado.ToLower())
                {
                    listado.Add(unP);
                }
            }
            return listado;
        }


        public string GenerarEmail(string nombre, string apellido)
        {

            string nombreCortado = "";
            string apellidoCortado = "";

            int largo = 3;
            if (nombre.Length < largo) 
                largo = nombre.Length;

            for (int i = 0; i<largo; i++)
            {
                nombreCortado += nombre[i];
            }

            largo = 3;
            if (apellido.Length < largo) 
                largo = apellido.Length;

            for (int i = 0; i<largo; i++)
            {
                apellidoCortado += apellido[i];
            }

            string nombreDeUsuario = nombreCortado.ToLower() + apellidoCortado.ToLower();

            string extension = "@laEmpresa.com";

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
