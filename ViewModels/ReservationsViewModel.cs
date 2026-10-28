using System.Collections.ObjectModel;
using ReservationSalles.Models;

namespace ReservationSalles.ViewModels;

public class ReservationsViewModel
{
    public ObservableCollection<Reservation> Reservations { get; }

    public ReservationsViewModel()
    {
        Reservations = ReservationService.Partage.Reservations;
    }
}