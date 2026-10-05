namespace ReservationSalles;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Route vers la liste des salles
        Routing.RegisterRoute(
            nameof(Pages.SallesPage),
            typeof(Pages.SallesPage));

        // Route vers le détail d'une salle
        Routing.RegisterRoute(
            nameof(Pages.SalleDetailPage),
            typeof(Pages.SalleDetailPage));

        // Route vers la page de réservation
        Routing.RegisterRoute(
            nameof(Pages.ReservationPage),
            typeof(Pages.ReservationPage));
    }
}