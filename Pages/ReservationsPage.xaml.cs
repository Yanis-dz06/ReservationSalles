using ReservationSalles.Models;

namespace ReservationSalles.Pages;

public partial class ReservationsPage : ContentPage
{
    public ReservationsPage()
    {
        InitializeComponent();

        ReservationsCollectionView.ItemsSource =
            ReservationService.Reservations;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ReservationsCollectionView.ItemsSource = null;

        ReservationsCollectionView.ItemsSource =
            ReservationService.Reservations;
    }
}