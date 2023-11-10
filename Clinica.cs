namespace SaludAr;

class Clinica
{
    private List<Servicio?> _historialFacturacion = new List<Servicio?>();

    public void AgregarServicio()
    {
        Console.WriteLine("Ingrese los detalles del servicio:");
        Console.Write("Tipo de servicio (1: Medicamento, 2: Internación, 3: Laboratorio): ");
        if (int.TryParse(Console.ReadLine(), out var tipoServicio))
        {
            Servicio? nuevoServicio;

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

            _historialFacturacion.Add(nuevoServicio);
            Console.WriteLine("Servicio agregado exitosamente.");
        }
        else
        {
            Console.WriteLine("Tipo de servicio no válido.");
        }
    }

    public void MostrarDetallesServicios()
    {
        foreach (var servicio in _historialFacturacion)
        {
            servicio?.MostrarDetalles();
            if (servicio != null) Console.WriteLine($"Precio final: {servicio.CalcularPrecio():C}\n");
        }
    }

    public decimal MontoTotalFacturado()
    {
        decimal montoTotal = 0;

        foreach (var servicio in _historialFacturacion)
        {
            if (servicio != null) montoTotal += servicio.CalcularPrecio();
        }

        return montoTotal;
    }

    public int CantServiciosSimples()
    {
        return _historialFacturacion.Count(servicio => servicio is ServicioLaboratorio { NivelComplejidad: < 3 });
    }


    private static Medicamento? CrearMedicamento()
    {
        Console.Write("Nombre del medicamento: ");
        var nombre = Console.ReadLine();
        Console.Write("Porcentaje de ganancia: ");
        if (decimal.TryParse(Console.ReadLine(), out var ganancia))
        {
            Console.Write("Precio de lista: ");
            if (decimal.TryParse(Console.ReadLine(), out var precioLista))
            {
                return new Medicamento(nombre, ganancia, precioLista);
            }
        }

        Console.WriteLine("Error al ingresar datos del medicamento. Volviendo al menú principal.");
        return null;
    }

    private static ServicioInternacion? CrearServicioInternacion()
    {
        Console.Write("Especialidad: ");
        var especialidad = Console.ReadLine();
        Console.Write("Cantidad de días internado: ");
        if (int.TryParse(Console.ReadLine(), out var diasInternado))
        {
            return new ServicioInternacion(especialidad, diasInternado);
        }

        Console.WriteLine("Error al ingresar datos del servicio de internación. Volviendo al menú principal.");
        return null;
    }

    private static ServicioLaboratorio? CrearServicioLaboratorio()
    {
        Console.Write("Nombre del estudio de laboratorio: ");
        var nombre = Console.ReadLine();
        Console.Write("Cantidad de días desde la muestra hasta el resultado: ");
        if (int.TryParse(Console.ReadLine(), out var diasLaboratorio))
        {
            Console.Write("Nivel de complejidad (1-5): ");
            if (int.TryParse(Console.ReadLine(), out var nivelComplejidad))
            {
                return new ServicioLaboratorio(nombre, diasLaboratorio, nivelComplejidad);
            }
        }

        Console.WriteLine("Error al ingresar datos del servicio de laboratorio. Volviendo al menú principal.");
        return null;
    }
}