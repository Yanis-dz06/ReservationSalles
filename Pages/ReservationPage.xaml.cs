using ReservationSalles.Models;

namespace ReservationSalles.Pages;

public partial class ReservationPage : ContentPage
{
    public ReservationPage()
    {
        InitializeComponent();

        SallePicker.Items.Add("Salle 101");
        SallePicker.Items.Add("Salle 102");
        SallePicker.Items.Add("Salle 201");
        SallePicker.Items.Add("Salle 202");

        HorairePicker.Items.Add("08:00 - 10:00");
        HorairePicker.Items.Add("10:00 - 12:00");
        HorairePicker.Items.Add("12:00 - 14:00");
        HorairePicker.Items.Add("14:00 - 16:00");
        HorairePicker.Items.Add("16:00 - 18:00");

        DateReservation.Date = DateTime.Today;
    }

    private async void OnReserverClicked(object sender, EventArgs e)
    {
        string nom = NomUtilisateur.Text?.Trim() ?? "";

        // Vérifier le nom
        if (string.IsNullOrWhiteSpace(nom))
        {
            await DisplayAlert(
                "Information manquante",
                "Veuillez entrer votre nom.",
                "OK");

            return;
        }

        // Vérifier la salle
        if (SallePicker.SelectedIndex == -1)
        {
            await DisplayAlert(
                "Information manquante",
                "Veuillez choisir une salle.",
                "OK");

            return;
        }

        // Vérifier l'horaire
        if (HorairePicker.SelectedIndex == -1)
        {
            await DisplayAlert(
                "Information manquante",
                "Veuillez choisir une plage horaire.",
                "OK");

            return;
        }

        string salle = SallePicker.SelectedItem?.ToString() ?? "";
        string horaire = HorairePicker.SelectedItem?.ToString() ?? "";
        DateTime date = DateReservation.Date;

        // Créer la nouvelle réservation
        Reservation nouvelleReservation = new Reservation
        {
            NomUtilisateur = nom,
            NomSalle = salle,
            Date = date,
            PlageHoraire = horaire
        };

        // Ajouter la réservation en vérifiant les doublons
        bool ajoutReussi =
            ReservationService.AjouterReservation(nouvelleReservation);

        // Si la salle est déjà réservée
        if (!ajoutReussi)
        {
            await DisplayAlert(
                "Salle indisponible",
                $"La {salle} est déjà réservée le {date:dd/MM/yyyy} de {horaire}.",
                "OK");

            return;
        }

        // Afficher la confirmation
        await DisplayAlert(
            "Réservation confirmée",
            $"Nom : {nom}\n" +
            $"Salle : {salle}\n" +
            $"Date : {date:dd/MM/yyyy}\n" +
            $"Plage horaire : {horaire}",
            "OK");
    }
}