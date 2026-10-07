namespace ReservationSalles.Models;

public class Reservation
{
    public string NomUtilisateur { get; set; } = string.Empty;

    public string NomSalle { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public string PlageHoraire { get; set; } = string.Empty;
}