using ReservationSalles.Models;
using ReservationSalles.ViewModels;

namespace ReservationSalles.Views;

public partial class SalleDetailPage : ContentPage, IQueryAttributable
{
    private readonly SalleDetailViewModel _viewModel;

    public SalleDetailPage()
    {
        InitializeComponent();

        _viewModel = new SalleDetailViewModel();
        BindingContext = _viewModel;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Salle", out object? valeur) &&
            valeur is Salle salle)
        {
            _viewModel.Salle = salle;
        }
    }
}