namespace SaludAr;

class MenuPrincipal
{
    private Clinica _clinica;

    public MenuPrincipal(Clinica clinica)
    {
        this._clinica = clinica;
    }

    public void EjecutarMenu()
    {
        int opcion;
        do
        {
            MostrarMenu();
            
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                ProcesarOpcion(opcion);
            }
            else
            {
                Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
            }

        } while (opcion != 3);

        MostrarResultados();
    }

    private void MostrarMenu()
    {
        Console.WriteLine("Menú:");
        Console.WriteLine("1. Agregar un nuevo servicio");
        Console.WriteLine("2. Mostrar detalles de los servicios");
        Console.WriteLine("3. Salir del programa");
        Console.Write("Seleccione una opción: ");
    }

    private void ProcesarOpcion(int opcion)
    {
        switch (opcion)
        {
            case 1:
                _clinica.AgregarServicio();
                break;
            case 2:
                _clinica.MostrarDetallesServicios();
                break;
            case 3:
                Console.WriteLine("Saliendo del programa...");
                break;
            default:
                Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                break;
        }
    }

    private void MostrarResultados()
    {
        Console.WriteLine($"Monto total facturado: {_clinica.MontoTotalFacturado():C}");
        Console.WriteLine($"Cantidad de servicios de laboratorio simples: {_clinica.CantServiciosSimples()}");
    }
}