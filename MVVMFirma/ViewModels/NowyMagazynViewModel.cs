using MVVMFirma.Models.Entities;
using MVVMFirma.ViewModels;

public class NowyMagazynViewModel : jedenViewModel<Magazyn>
{
    #region Fields
    private readonly Faktury2024Entities fakturyEntities;
    #endregion

    #region Constructor
    public NowyMagazynViewModel()
        : base("Magazyn")
    {
        item = new Magazyn();
        fakturyEntities = new Faktury2024Entities();
    }
    #endregion

    #region Properties
    public string Nazwa
    {
        get
        {
            return item.Nazwa;
        }
        set
        {
            if (value != item.Nazwa)
            {
                item.Nazwa = value;
                OnPropertyChanged(() => Nazwa);
            }
        }
    }
    public string Lokalizacja
    {
        get
        {
            return item.Lokalizacja;
        }
        set
        {
            if (value != item.Lokalizacja)
            {
                item.Lokalizacja = value;
                OnPropertyChanged(() => Lokalizacja);
            }
        }
    }
    public int? Pojemnosc
    {
        get
        {
            return item.Pojemnosc;
        }
        set
        {
            if (value != item.Pojemnosc)
            {
                item.Pojemnosc = value;
                OnPropertyChanged(() => Pojemnosc);
            }
        }
    }

    public string Status
    {
        get
        {
            return item.Status;
        }
        set
        {
            if (value != item.Status)
            {
                item.Status = value;
                OnPropertyChanged(() => Status);
            }
        }
    }
    #endregion

    #region Helpers
    public override void Save()
    {
        fakturyEntities.Magazyn.Add(item);
        fakturyEntities.SaveChanges();
    }
    protected override string ValidateProperty(string propertyname)
    {
        switch (propertyname)
        {
            case nameof(Nazwa):
                return string.IsNullOrEmpty(Nazwa) ? "Nazwa jest wymagana" : string.Empty;

            case nameof(Lokalizacja):
                return string.IsNullOrEmpty(Lokalizacja) ? "Lokalizacja jest wymagana" : string.Empty;

            case nameof(Pojemnosc):
                return !Pojemnosc.HasValue ? "Pojemność jest wymagana" : string.Empty;

            case nameof(Status):
                return string.IsNullOrEmpty(Status) ? "Status jest wymagany" : string.Empty;

            default:
                return string.Empty;
        }
    }
    #endregion
}