using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowaFakturaViewModel : jedenViewModel<Faktura>
    {
        #region Konstruktor


        public NowaFakturaViewModel() : base("Faktura")
        {
            item = new Faktura();
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


        #endregion
        #region Helpers
        public override void Save()
        {
            FakturyEntities.Faktura.Add(item); // dodaje towar do lokalnej kolekcji 
            FakturyEntities.SaveChanges(); // zapisuje zmiany do bazy danych

        }

        #endregion
    }
}
