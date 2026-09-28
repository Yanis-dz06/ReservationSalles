using ReservationSalles.Models;

namespace ReservationSalles.Pages;

public partial class SalleDetailPage : ContentPage
{
    public SalleDetailPage(Salle salle)
    {
        InitializeComponent();

        BindingContext = salle;
    }
}