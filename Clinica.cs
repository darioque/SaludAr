namespace SaludAr;

class Clinica
{
    private List<Servicio> historialFacturacion = new List<Servicio>();

    public void AgregarServicio()
    {
        Console.WriteLine("Ingrese los detalles del servicio:");
        Console.Write("Tipo de servicio (1: Medicamento, 2: Internación, 3: Laboratorio): ");
        if (int.TryParse(Console.ReadLine(), out int tipoServicio))
        {
            Servicio nuevoServicio = null;

            switch (tipoServicio)
            {
                case 1:
                    nuevoServicio = CrearMedicamento();
                    break;
                case 2:
                    nuevoServicio = CrearServicioInternacion();
                    break;
                case 3:
                    nuevoServicio = CrearServicioLaboratorio();
                    break;
                default:
                    Console.WriteLine("Tipo de servicio no válido.");
                    return;
            }

            historialFacturacion.Add(nuevoServicio);
            Console.WriteLine("Servicio agregado exitosamente.");
        }
        else
        {
            Console.WriteLine("Tipo de servicio no válido.");
        }
    }

    public void MostrarDetallesServicios()
    {
        foreach (var servicio in historialFacturacion)
        {
            servicio.MostrarDetalles();
            Console.WriteLine($"Precio final: {servicio.CalcularPrecio():C}\n");
        }
    }

    public decimal MontoTotalFacturado()
    {
        decimal montoTotal = 0;

        foreach (var servicio in historialFacturacion)
        {
            montoTotal += servicio.CalcularPrecio();
        }

        return montoTotal;
    }

    public int CantServiciosSimples()
    {
        int cantidadServiciosSimples = 0;

        foreach (var servicio in historialFacturacion)
        {
            if (servicio is ServicioLaboratorio laboratorio && laboratorio.NivelComplejidad < 3)
            {
                cantidadServiciosSimples++;
            }
        }

        return cantidadServiciosSimples;
    }

    
    public Medicamento CrearMedicamento()
    {
        Console.Write("Nombre del medicamento: ");
        string nombre = Console.ReadLine();
        Console.Write("Porcentaje de ganancia: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal ganancia))
        {
            Console.Write("Precio de lista: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal precioLista))
            {
                return new Medicamento(nombre, ganancia, precioLista);
            }
        }

        Console.WriteLine("Error al ingresar datos del medicamento. Volviendo al menú principal.");
        return null;
    }

    public ServicioInternacion CrearServicioInternacion()
    {
        Console.Write("Especialidad: ");
        string especialidad = Console.ReadLine();
        Console.Write("Cantidad de días internado: ");
        if (int.TryParse(Console.ReadLine(), out int diasInternado))
        {
            return new ServicioInternacion(especialidad, diasInternado);
        }

        Console.WriteLine("Error al ingresar datos del servicio de internación. Volviendo al menú principal.");
        return null;
    }

    public ServicioLaboratorio CrearServicioLaboratorio()
    {
        Console.Write("Nombre del estudio de laboratorio: ");
        string nombre = Console.ReadLine();
        Console.Write("Cantidad de días desde la muestra hasta el resultado: ");
        if (int.TryParse(Console.ReadLine(), out int diasLaboratorio))
        {
            Console.Write("Nivel de complejidad (1-5): ");
            if (int.TryParse(Console.ReadLine(), out int nivelComplejidad))
            {
                return new ServicioLaboratorio(nombre, diasLaboratorio, nivelComplejidad);
            }
        }

        Console.WriteLine("Error al ingresar datos del servicio de laboratorio. Volviendo al menú principal.");
        return null;
    }
}