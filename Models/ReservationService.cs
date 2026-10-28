using System.Collections.ObjectModel;
using System.Linq;

namespace ReservationSalles.Models;

public class ReservationService
{
    public static ReservationService Partage { get; } = new();

    public ObservableCollection<Reservation> Reservations { get; } = new();

    public Reservation? Selectionnee { get; set; }

    public bool AjouterReservation(Reservation reservation)
    {
        bool existeDeja = Reservations.Any(r =>
            r.NomSalle == reservation.NomSalle &&
            r.Date.Date == reservation.Date.Date &&
            r.PlageHoraire == reservation.PlageHoraire
        );

        if (existeDeja)
        {
            return false;
        }

        Reservations.Insert(0, reservation);
        return true;
    }
}