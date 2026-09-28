namespace ReservationSalles;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(
            nameof(Pages.SallesPage),
            typeof(Pages.SallesPage));
    }
}