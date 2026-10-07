using System.Collections.Generic;
using System.Linq;

namespace ReservationSalles.Models;

public static class ReservationService
{
    public static List<Reservation> Reservations { get; } = new();

    public static bool AjouterReservation(Reservation reservation)
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

        Reservations.Add(reservation);
        return true;
    }
}