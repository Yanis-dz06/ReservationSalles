namespace ReservationSalles.Pages;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();
    }

    private async void OnVoirLesSallesClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SallesPage));
    }
}