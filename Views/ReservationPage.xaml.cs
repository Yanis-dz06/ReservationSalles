using ReservationSalles.ViewModels;

namespace ReservationSalles.Views;

public partial class ReservationPage : ContentPage
{
    public ReservationPage()
    {
        InitializeComponent();

        BindingContext = new ReservationViewModel();
    }
}