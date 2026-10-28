using System.ComponentModel;
using ReservationSalles.Models;

namespace ReservationSalles.ViewModels;

public class ReservationViewModel : INotifyPropertyChanged
{
    private string _nomUtilisateur = "";
    private string _salleSelectionnee = "";
    private DateTime _dateReservation = DateTime.Today;
    private string _horaireSelectionne = "";

    public event PropertyChangedEventHandler? PropertyChanged;

    public string NomUtilisateur
    {
        get => _nomUtilisateur;
        set
        {
            _nomUtilisateur = value;

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(NomUtilisateur)));
        }
    }

    public List<string> Salles { get; } = new()
    {
        "Salle 101",
        "Salle 102",
        "Salle 201",
        "Salle 202"
    };

    public string SalleSelectionnee
    {
        get => _salleSelectionnee;
        set
        {
            _salleSelectionnee = value;

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(SalleSelectionnee)));
        }
    }

    public DateTime DateReservation
    {
        get => _dateReservation;
        set
        {
            _dateReservation = value;

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(DateReservation)));
        }
    }

    public List<string> Horaires { get; } = new()
    {
        "08:00 - 10:00",
        "10:00 - 12:00",
        "12:00 - 14:00",
        "14:00 - 16:00",
        "16:00 - 18:00"
    };

    public string HoraireSelectionne
    {
        get => _horaireSelectionne;
        set
        {
            _horaireSelectionne = value;

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(HoraireSelectionne)));
        }
    }

    public Command ReserverCommand { get; }

    public ReservationViewModel()
    {
        ReserverCommand = new Command(async () =>
        {
            await Reserver();
        });
    }

    private async Task Reserver()
    {
        // Vérifier le nom
        if (string.IsNullOrWhiteSpace(NomUtilisateur))
        {
            await Shell.Current.DisplayAlert(
                "Information manquante",
                "Veuillez entrer votre nom.",
                "OK");

            return;
        }

        // Vérifier la salle
        if (string.IsNullOrWhiteSpace(SalleSelectionnee))
        {
            await Shell.Current.DisplayAlert(
                "Information manquante",
                "Veuillez choisir une salle.",
                "OK");

            return;
        }

        // Vérifier l'horaire
        if (string.IsNullOrWhiteSpace(HoraireSelectionne))
        {
            await Shell.Current.DisplayAlert(
                "Information manquante",
                "Veuillez choisir une plage horaire.",
                "OK");

            return;
        }

        Reservation nouvelleReservation = new Reservation
        {
            NomUtilisateur = NomUtilisateur.Trim(),
            NomSalle = SalleSelectionnee,
            Date = DateReservation,
            PlageHoraire = HoraireSelectionne
        };

        bool ajoutReussi =
            ReservationService.Partage.AjouterReservation(
                nouvelleReservation);

        if (!ajoutReussi)
        {
            await Shell.Current.DisplayAlert(
                "Salle indisponible",
                $"La {SalleSelectionnee} est déjà réservée le {DateReservation:dd/MM/yyyy} de {HoraireSelectionne}.",
                "OK");

            return;
        }

        await Shell.Current.DisplayAlert(
            "Réservation confirmée",
            $"Nom : {NomUtilisateur}\n" +
            $"Salle : {SalleSelectionnee}\n" +
            $"Date : {DateReservation:dd/MM/yyyy}\n" +
            $"Plage horaire : {HoraireSelectionne}",
            "OK");
    }
}