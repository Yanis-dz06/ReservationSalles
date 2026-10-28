using System.ComponentModel;
using ReservationSalles.Models;

namespace ReservationSalles.ViewModels;

public class DashboardViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public int NombreReservations =>
        ReservationService.Partage.Reservations.Count;

    public int NombreSallesDisponibles => 10;

    public Command VoirLesSallesCommand { get; }

    public DashboardViewModel()
    {
        VoirLesSallesCommand = new Command(async () =>
        {
            await Shell.Current.GoToAsync(nameof(Views.SallesPage));
        });
    }

    public void Actualiser()
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(nameof(NombreReservations)));
    }
}