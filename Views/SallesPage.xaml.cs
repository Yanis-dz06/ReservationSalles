using ReservationSalles.ViewModels;

namespace ReservationSalles.Views;

public partial class SallesPage : ContentPage
{
    public SallesPage()
    {
        InitializeComponent();

        BindingContext = new SallesViewModel();
    }
}