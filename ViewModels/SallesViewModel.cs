using ReservationSalles.Models;

namespace ReservationSalles.ViewModels;

public class SallesViewModel
{
    public List<Salle> Salles { get; }

    public Command<Salle> VoirSalleCommand { get; }

    public SallesViewModel()
    {
        Salles = new List<Salle>
        {
            new Salle
            {
                Nom = "Salle 101",
                Capacite = 30,
                Localisation = "Pavillon A",
                Disponible = true,
                Equipements = new List<string>
                {
                    "Projecteur",
                    "Tableau blanc",
                    "Wi-Fi"
                }
            },

            new Salle
            {
                Nom = "Salle 102",
                Capacite = 20,
                Localisation = "Pavillon A",
                Disponible = false,
                Equipements = new List<string>
                {
                    "Tableau blanc",
                    "Wi-Fi"
                }
            },

            new Salle
            {
                Nom = "Salle 201",
                Capacite = 50,
                Localisation = "Pavillon B",
                Disponible = true,
                Equipements = new List<string>
                {
                    "Projecteur",
                    "Écran",
                    "Wi-Fi",
                    "Système audio"
                }
            },

            new Salle
            {
                Nom = "Salle 202",
                Capacite = 40,
                Localisation = "Pavillon B",
                Disponible = true,
                Equipements = new List<string>
                {
                    "Projecteur",
                    "Tableau blanc",
                    "Visioconférence",
                    "Wi-Fi"
                }
            }
        };

        VoirSalleCommand = new Command<Salle>(async salle =>
        {
            if (salle == null)
                return;

            await Shell.Current.GoToAsync(
                nameof(Views.SalleDetailPage),
                new Dictionary<string, object>
                {
                    ["Salle"] = salle
                });
        });
    }
}