namespace ReservationSalles;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Route vers la liste des salles
        Routing.RegisterRoute(
            nameof(Views.SallesPage),
            typeof(Views.SallesPage));

        // Route vers le détail d'une salle
        Routing.RegisterRoute(
            nameof(Views.SalleDetailPage),
            typeof(Views.SalleDetailPage));

        // Route vers la page de réservation
        Routing.RegisterRoute(
            nameof(Views.ReservationPage),
            typeof(Views.ReservationPage));

        // Route vers mes réservations
        Routing.RegisterRoute(
            nameof(Views.ReservationsPage),
            typeof(Views.ReservationsPage));
    }
}