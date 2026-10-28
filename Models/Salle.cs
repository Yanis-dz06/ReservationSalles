namespace ReservationSalles.Models;

public class Salle
{
    public string Nom { get; set; } = string.Empty;

    public int Capacite { get; set; }

    public string Localisation { get; set; } = string.Empty;

    public bool Disponible { get; set; }

    public string Statut => Disponible ? "Disponible" : "Occupée";

    public Color StatutCouleur =>
        Disponible ? Colors.Green : Colors.Red;

    public List<string> Equipements { get; set; } = new();
}