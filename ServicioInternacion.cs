namespace SaludAr;

class ServicioInternacion : Servicio
{
    private string Especialidad { get; set; }
    private int DiasInternado { get; set; }

    public ServicioInternacion(string especialidad, int diasInternado)
    {
        Especialidad = especialidad;
        DiasInternado = diasInternado;
    }

    public override decimal CalcularPrecio()
    {
        return DiasInternado * 20000M; // $20,000 por día de internación
    }

    public override void MostrarDetalles()
    {
        Console.WriteLine($"Servicio de Internación - Especialidad: {Especialidad}, Días internado: {DiasInternado}");
    }
}