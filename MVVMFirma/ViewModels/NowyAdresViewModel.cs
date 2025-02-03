using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class NowyAdresViewModel : jedenViewModel<Adres>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion

        #region Constructor
        public NowyAdresViewModel()
            : base("Adres")
        {
            item = new Adres();
            fakturyEntities = new Faktury2024Entities();
        }
        #endregion

        #region Properties
        public string Miejscowość
        {
            get
            {
                return item.Miejscowość;
            }
            set
            {
                if (value != item.Miejscowość)
                {
                    item.Miejscowość = value;
                    OnPropertyChanged(() => Miejscowość);
                }
            }
        }

        public string Ulica
        {
            get
            {
                return item.Ulica;
            }
            set
            {
                if (value != item.Ulica)
                {
                    item.Ulica = value;
                    OnPropertyChanged(() => Ulica);
                }
            }
        }

        public string NrDomu
        {
            get
            {
                return item.NrDomu;
            }
            set
            {
                if (value != item.NrDomu)
                {
                    item.NrDomu = value;
                    OnPropertyChanged(() => NrDomu);
                }
            }
        }

        public string NrLokalu
        {
            get
            {
                return item.NrLokalu;
            }
            set
            {
                if (value != item.NrLokalu)
                {
                    item.NrLokalu = value;
                    OnPropertyChanged(() => NrLokalu);
                }
            }
        }

        public string KodPocztowy
        {
            get
            {
                return item.KodPocztowy;
            }
            set
            {
                if (value != item.KodPocztowy)
                {
                    item.KodPocztowy = value;
                    OnPropertyChanged(() => KodPocztowy);
                }
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            fakturyEntities.Adres.Add(item);
            fakturyEntities.SaveChanges();
        }
        protected override string ValidateProperty(string propertyname)
        {
            switch (propertyname)
            {
                case nameof(Miejscowość):
                    return string.IsNullOrEmpty(Miejscowość) ? "Miejscowość jest wymagana" : string.Empty;

                case nameof(Ulica):
                    return string.IsNullOrEmpty(Ulica) ? "Ulica jest wymagana" : string.Empty;

                case nameof(NrDomu):
                    return string.IsNullOrEmpty(NrDomu) ? "Numer domu jest wymagany" : string.Empty;

                case nameof(KodPocztowy):
                    return string.IsNullOrEmpty(KodPocztowy) ? "Kod pocztowy jest wymagany" : string.Empty;

                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}