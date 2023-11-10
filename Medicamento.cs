namespace SaludAr;

class Medicamento : Servicio
{
    private string? Nombre { get; set; }
    private decimal PorcentajeGanancia { get; set; }
    private decimal PrecioLista { get; set; }

    public Medicamento(string? nombre, decimal porcentajeGanancia, decimal precioLista)
    {
        Nombre = nombre;
        PorcentajeGanancia = porcentajeGanancia;
        PrecioLista = precioLista;
    }

    public override decimal CalcularPrecio()
    {
        var precioFinal = PrecioLista + (PorcentajeGanancia * PrecioLista / 100);
        precioFinal += precioFinal * 0.21M; // Agregar el 21% de IVA
        return precioFinal;
    }

    public override void MostrarDetalles()
    {
        Console.WriteLine($"Medicamento: {Nombre}");
        Console.WriteLine($"Porcentaje de ganancia: {PorcentajeGanancia}%");
        Console.WriteLine($"Precio de lista: {PrecioLista:C}");
    }
}