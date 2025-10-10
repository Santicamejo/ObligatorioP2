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
                        MostrarEquipos();
                        Continuar();
                        break;
                    case 3:
                        Cargando();
                        sistema.AltaUsuario();
                        Continuar();
                        break;
                    case 4:
                        Cargando();
                        // otra opción
                        break;
                }
             
                sistema.Menu();
                opcion = sistema.Opcion();

            }
        }

        private static void Continuar()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void MostrarEquipos()
        {
            Console.Clear();
            Console.WriteLine("=== EQUIPOS ===");

            List<Equipo> equipos = sistema.GetEquipos();

            if (equipos.Count > 0)
            {
                foreach (Equipo unE in equipos)
                    Console.WriteLine(unE.ToString());
            }
            else
            {
                Console.WriteLine("No existen equipos en el sistema");
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
                    Console.WriteLine(unU.ToString());
            }
            else
            {
                Console.WriteLine("No existen usuarios en el sistema");
            }
        }




        //Funcion For fun
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
