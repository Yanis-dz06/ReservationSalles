using System.ComponentModel;
using ReservationSalles.Models;

namespace ReservationSalles.ViewModels;

public class SalleDetailViewModel : INotifyPropertyChanged
{
    private Salle? _salle;

    public event PropertyChangedEventHandler? PropertyChanged;

    public Salle? Salle
    {
        get => _salle;
        set
        {
            _salle = value;

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(Salle)));
        }
    }

    public Command ReserverCommand { get; }

    public SalleDetailViewModel()
    {
        ReserverCommand = new Command(async () =>
        {
            if (Salle == null)
                return;

            await Shell.Current.GoToAsync(
                nameof(Views.ReservationPage),
                new Dictionary<string, object>
                {
                    { "Salle", Salle }
                });
        });
    }
}