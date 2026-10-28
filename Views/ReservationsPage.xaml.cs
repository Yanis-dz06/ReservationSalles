using ReservationSalles.ViewModels;

namespace ReservationSalles.Views;

public partial class ReservationsPage : ContentPage
{
    public ReservationsPage()
    {
        InitializeComponent();

        BindingContext = new ReservationsViewModel();
    }
}