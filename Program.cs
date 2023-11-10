namespace SaludAr;

class Program
{
    private static void Main()
    {
        Clinica clinica = new Clinica();
        MenuPrincipal menu = new MenuPrincipal(clinica);

        menu.EjecutarMenu();
    }
}