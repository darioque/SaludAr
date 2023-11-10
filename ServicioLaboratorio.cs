namespace SaludAr;

class ServicioLaboratorio : Servicio
{
    private string Nombre { get; set; }
    private int DiasLaboratorio { get; set; }
    public int NivelComplejidad { get; set; }

    public ServicioLaboratorio(string nombre, int diasLaboratorio, int nivelComplejidad)
    {
        Nombre = nombre;
        DiasLaboratorio = diasLaboratorio;
        NivelComplejidad = nivelComplejidad;
    }

    public override decimal CalcularPrecio()
    {
        decimal precio = DiasLaboratorio * 10000M; // $10,000 por día de laboratorio

        if (NivelComplejidad > 3)
        {
            precio += precio * 0.25M; // Incrementar el precio en un 25% si el nivel de complejidad es mayor a 3
        }

        precio += precio * 0.21M; // Agregar el 21% de IVA
        return precio;
    }

    public override void MostrarDetalles()
    {
        Console.WriteLine($"Servicio de Laboratorio - Nombre: {Nombre}, Días de laboratorio: {DiasLaboratorio}, Nivel de complejidad: {NivelComplejidad}");
    }
}