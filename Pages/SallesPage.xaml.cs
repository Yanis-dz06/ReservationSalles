using ReservationSalles.Models;

namespace ReservationSalles.Pages;

public partial class SallesPage : ContentPage
{
    public List<Salle> Salles { get; set; }

    public SallesPage()
    {
        InitializeComponent();

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

        BindingContext = this;
    }

    private async void OnVoirClicked(object sender, EventArgs e)
    {
        if (sender is Button button &&
            button.BindingContext is Salle salle)
        {
            await Navigation.PushAsync(new SalleDetailPage(salle));
        }
    }
}