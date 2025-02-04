using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowaFakturaViewModel : jedenViewModel<Faktura>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        private ObservableCollection<KontrahentForComboBox> _kontrahenciList;
        private ObservableCollection<SposobPlatnosciForComboBox> _sposobyPlatnosciList;
        private string _kontrahentNazwa;
        #endregion

        #region Constructor
        public NowaFakturaViewModel() : base("Faktura")
        {
            item = new Faktura();
            fakturyEntities = new Faktury2024Entities();

            KontrahenciList = new ObservableCollection<KontrahentForComboBox>(
                fakturyEntities.Kontrahent.Select(kontrahent => new KontrahentForComboBox
                {
                    IdKontrahenta = kontrahent.IdKontrahenta,
                    NazwaKontrahenta = kontrahent.Nazwa + " (NIP: " + kontrahent.NIP + ")"
                }).ToList()
            );

            SposobyPlatnosciList = new ObservableCollection<SposobPlatnosciForComboBox>(
                fakturyEntities.SposóbPłatności.Select(sp => new SposobPlatnosciForComboBox
                {
                    IdSposobuPłatności = sp.IdSposobuPłatności,
                    Nazwa = sp.Nazwa
                }).ToList()
            );

            item.DataWystawienia = DateTime.Now;
            Messenger.Default.Register<Kontrahent>(this, getWybranyKontrahent);
        }
        #endregion

        #region Properties
        public string Numer
        {
            get { return item.Numer; }
            set
            {
                item.Numer = value;
                OnPropertyChanged(() => Numer);
            }
        }

        public bool? CzyZatwierdzona
        {
            get { return item.CzyZatwierdzona; }
            set
            {
                item.CzyZatwierdzona = value;
                OnPropertyChanged(() => CzyZatwierdzona);
            }
        }

        public DateTime? DataWystawienia
        {
            get { return item.DataWystawienia; }
            set
            {
                item.DataWystawienia = value;
                OnPropertyChanged(() => DataWystawienia);
            }
        }

        public DateTime? TerminPłatności
        {
            get { return item.TerminPłatności; }
            set
            {
                item.TerminPłatności = value;
                OnPropertyChanged(() => TerminPłatności);
            }
        }

        public int? IdKontrahenta
        {
            get { return item.IdKontrahenta; }
            set
            {
                item.IdKontrahenta = value;
                OnPropertyChanged(() => IdKontrahenta);
            }
        }

        public int? IdSposobuPłatności
        {
            get { return item.IdSposobuPłatności; }
            set
            {
                item.IdSposobuPłatności = value;
                OnPropertyChanged(() => IdSposobuPłatności);
            }
        }

        public string KontrahentNazwaPole { get; set; }
        public string KontrahentNipPole { get; set; }

        public ObservableCollection<KontrahentForComboBox> KontrahenciList
        {
            get { return _kontrahenciList; }
            set
            {
                _kontrahenciList = value;
                OnPropertyChanged(() => KontrahenciList);
            }
        }

        public ObservableCollection<SposobPlatnosciForComboBox> SposobyPlatnosciList
        {
            get { return _sposobyPlatnosciList; }
            set
            {
                _sposobyPlatnosciList = value;
                OnPropertyChanged(() => SposobyPlatnosciList);
            }
        }
        #endregion

        #region Commands
        private BaseCommand _ShowKontrahenci;
        public ICommand ShowKontrahenci
        {
            get
            {
                if (_ShowKontrahenci == null)
                    _ShowKontrahenci = new BaseCommand(() => showKontrahenci());
                return _ShowKontrahenci;
            }
        }
        #endregion

        #region Classes
        public class KontrahentForComboBox
        {
            public int IdKontrahenta { get; set; }
            public string NazwaKontrahenta { get; set; }
        }

        public class SposobPlatnosciForComboBox
        {
            public int IdSposobuPłatności { get; set; }
            public string Nazwa { get; set; }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            fakturyEntities.Faktura.Add(item);
            fakturyEntities.SaveChanges();
        }

        private void showKontrahenci()
        {
            Messenger.Default.Send("KontrahenciAll");
        }

        private void getWybranyKontrahent(Kontrahent kontrahent)
        {
            IdKontrahenta = kontrahent.IdKontrahenta;
            KontrahentNipPole = kontrahent.NIP;
            KontrahentNazwaPole = kontrahent.Nazwa;
        }

        protected override string ValidateProperty(string propertyname)
        {
            switch (propertyname)
            {
                case nameof(Numer):
                    return string.IsNullOrEmpty(Numer) ? "Numer faktury jest wymagany" : string.Empty;
                case nameof(DataWystawienia):
                    return !DataWystawienia.HasValue ? "Data wystawienia jest wymagana" : string.Empty;
                case nameof(TerminPłatności):
                    if (!TerminPłatności.HasValue)
                        return "Termin płatności jest wymagany";
                    if (DataWystawienia.HasValue && TerminPłatności.Value < DataWystawienia.Value)
                        return "Termin płatności nie może być wcześniejszy niż data wystawienia";
                    return string.Empty;
                case nameof(IdKontrahenta):
                    return !IdKontrahenta.HasValue ? "Kontrahent jest wymagany" : string.Empty;
                case nameof(IdSposobuPłatności):
                    return !IdSposobuPłatności.HasValue ? "Sposób płatności jest wymagany" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}