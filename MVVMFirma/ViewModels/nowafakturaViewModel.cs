using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
namespace MVVMFirma.ViewModels
{
    public class NowaFakturaViewModel : jedenViewModel<Faktura>
    {
         #region Fields
    private readonly Faktury2024Entities fakturyEntities;
    private ObservableCollection<KontrahentForComboBox> _kontrahenciList;
    private ObservableCollection<SposobPlatnosciForComboBox> _sposobyPlatnosciList;
        #endregion
        #region Konstruktor
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
        }
        #endregion
        #region Properties
        public string Numer
        {
            get
            {
                return item.Numer;
            }
            set
            {
                item.Numer = value;
                OnPropertyChanged(() => Numer);
            }
        }
        public bool? CzyZatwierdzona
        {
            get
            {
                return item.CzyZatwierdzona;
            }
            set
            {
                item.CzyZatwierdzona = value;
                OnPropertyChanged(() => CzyZatwierdzona);
            }
        }
        public DateTime? DataWystawienia
        {
            get
            {
                return item.DataWystawienia;
            }
            set
            {
                item.DataWystawienia = value;
                OnPropertyChanged(() => DataWystawienia);
            }
        }
        public int? KontrahentNIP
        {
            get
            {
                return item.IdKontrahenta;
            }
            set
            {
                item.IdKontrahenta = value;
                OnPropertyChanged(() => KontrahentNIP);
            }
        }
        private string _kontrahentNazwa;
        public string KontrahentNazwa
        {
            get
            {
                return _kontrahentNazwa;
            }
            set
            {
                _kontrahentNazwa = value;
                OnPropertyChanged(() => KontrahentNazwa);
            }
        }
        public DateTime? TerminPlatosci
        {
            get
            {
                return TerminPlatosci;
            }
            set
            {
                TerminPlatosci = value;
                OnPropertyChanged(() => TerminPlatosci);
            }
        }
        public string SposobuPlatnosciNazwa
        {
            get
            {
                return SposobuPlatnosciNazwa;
            }
            set
            {
                {
                    SposobuPlatnosciNazwa = value;
                    OnPropertyChanged(() => SposobuPlatnosciNazwa);
                }
            }
        }
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
        #region Helpers
        public override void Save()
        {
            FakturyEntities.Faktura.Add(item); // dodaje towar do lokalnej kolekcji 
            FakturyEntities.SaveChanges(); // zapisuje zmiany do bazy danych
        }
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
    }
}