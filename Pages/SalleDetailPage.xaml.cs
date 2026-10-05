using ReservationSalles.Models;

namespace ReservationSalles.Pages;

public partial class SalleDetailPage : ContentPage, IQueryAttributable
{
    public SalleDetailPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Salle", out object? valeur) &&
            valeur is Salle salle)
        {
            BindingContext = salle;
        }
    }

    private async void OnReserverClicked(object sender, EventArgs e)
    {
        if (BindingContext is Salle salle)
        {
            await Shell.Current.GoToAsync(
                nameof(ReservationPage),
                new Dictionary<string, object>
                {
                    { "Salle", salle }
                });
        }
    }
}