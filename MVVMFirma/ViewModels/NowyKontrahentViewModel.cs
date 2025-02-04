using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class NowyKontrahentViewModel : jedenViewModel<Kontrahent>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        private ObservableCollection<RodzajForComboBox> _rodzajeList;
        private ObservableCollection<AdresForComboBox> _adresyList;
        private ObservableCollection<StatusForComboBox> _statusyList;
        #endregion

        #region Constructor
        public NowyKontrahentViewModel() : base("Kontrahent")
        {
            item = new Kontrahent();
            fakturyEntities = new Faktury2024Entities();

            RodzajeList = new ObservableCollection<RodzajForComboBox>(
                fakturyEntities.Rodzaj.Select(rodzaj => new RodzajForComboBox
                {
                    IdRodzaju = rodzaj.IdRodzaju,
                    Nazwa = rodzaj.Nazwa
                }).ToList()
            );

            AdresyList = new ObservableCollection<AdresForComboBox>(
                fakturyEntities.Adres.Select(adres => new AdresForComboBox
                {
                    IdAdresu = adres.IdAdresu,
                    PelnyAdres = adres.Miejscowość + ", " + adres.Ulica + " " +
                                adres.NrDomu + (adres.NrLokalu != null ? "/" + adres.NrLokalu : "") +
                                ", " + adres.KodPocztowy
                }).ToList()
            );

            StatusyList = new ObservableCollection<StatusForComboBox>(
                fakturyEntities.Status.Select(status => new StatusForComboBox
                {
                    IdStatusu = status.IdStatus,
                    Nazwa = status.Nazwa
                }).ToList()
            );
        }
        #endregion

        #region Properties
        public string Kod
        {
            get
            {
                return item.Kod;
            }
            set
            {
                if (value != item.Kod)
                {
                    item.Kod = value;
                    OnPropertyChanged(() => Kod);
                }
            }
        }

        public string NIP
        {
            get
            {
                return item.NIP;
            }
            set
            {
                if (value != item.NIP)
                {
                    item.NIP = value;
                    OnPropertyChanged(() => NIP);
                }
            }
        }

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

        public int? IdRodzaju
        {
            get
            {
                return item.IdRodzaju;
            }
            set
            {
                if (value != item.IdRodzaju)
                {
                    item.IdRodzaju = value;
                    OnPropertyChanged(() => IdRodzaju);
                }
            }
        }

        public int? IdStatusu
        {
            get
            {
                return item.IdStatusu;
            }
            set
            {
                if (value != item.IdStatusu)
                {
                    item.IdStatusu = value;
                    OnPropertyChanged(() => IdStatusu);
                }
            }
        }

        public int? IdAdresu
        {
            get
            {
                return item.IdAdresu;
            }
            set
            {
                if (value != item.IdAdresu)
                {
                    item.IdAdresu = value;
                    OnPropertyChanged(() => IdAdresu);
                }
            }
        }

        public ObservableCollection<RodzajForComboBox> RodzajeList
        {
            get { return _rodzajeList; }
            set
            {
                _rodzajeList = value;
                OnPropertyChanged(() => RodzajeList);
            }
        }

        public ObservableCollection<AdresForComboBox> AdresyList
        {
            get { return _adresyList; }
            set
            {
                _adresyList = value;
                OnPropertyChanged(() => AdresyList);
            }
        }

        public ObservableCollection<StatusForComboBox> StatusyList
        {
            get { return _statusyList; }
            set
            {
                _statusyList = value;
                OnPropertyChanged(() => StatusyList);
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            fakturyEntities.Kontrahent.Add(item);
            fakturyEntities.SaveChanges();
        }

        public class RodzajForComboBox
        {
            public int IdRodzaju { get; set; }
            public string Nazwa { get; set; }
        }

        public class AdresForComboBox
        {
            public int IdAdresu { get; set; }
            public string PelnyAdres { get; set; }
        }

        public class StatusForComboBox
        {
            public int IdStatusu { get; set; }
            public string Nazwa { get; set; }
        }

        protected override string ValidateProperty(string propertyname)
        {
            switch (propertyname)
            {
                case nameof(Kod):
                    return string.IsNullOrEmpty(Kod) ? "Kod jest wymagany" : string.Empty;

                case nameof(NIP):
                    return string.IsNullOrEmpty(NIP) ? "NIP jest wymagany" : string.Empty;

                case nameof(Nazwa):
                    return string.IsNullOrEmpty(Nazwa) ? "Nazwa jest wymagana" : string.Empty;

                case nameof(IdRodzaju):
                    return !IdRodzaju.HasValue ? "Rodzaj jest wymagany" : string.Empty;

                case nameof(IdAdresu):
                    return !IdAdresu.HasValue ? "Adres jest wymagany" : string.Empty;

                case nameof(IdStatusu):
                    return !IdStatusu.HasValue ? "Status jest wymagany" : string.Empty;

                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}