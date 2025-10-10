using Dominio;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema sistema = Sistema.Instancia;


            sistema.Menu();
            int opcion = sistema.IngresoOpcion();

            while (opcion != 0)
            {
                sistema.Menu();
                switch (opcion)
                {
                    case 0: return;
                    case 1:
                        sistema.MostrarUsuarios();
                        break;
                    case 2:
                        sistema.MostrarEquipos();
                        break;
                    case 3:
                        sistema.AltaUsuario();
                        break;
                    case 4: break;
                }
                opcion = sistema.IngresoOpcion();
                sistema.Menu();
            }


        }
    }
}
