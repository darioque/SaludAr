namespace SaludAr;

class Program
{
    private static void Main()
    {
        var clinica = new Clinica();
        var menu = new MenuPrincipal(clinica);

        menu.EjecutarMenu();
    }
}