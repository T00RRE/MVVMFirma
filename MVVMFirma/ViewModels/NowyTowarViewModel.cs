using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowyTowarViewModel : jedenViewModel<Towar>
    {
       
        #region Konstruktor
        public NowyTowarViewModel():base("Towar")
        { 
            item = new Towar();
        }
        #endregion
        #region Properties
        //dla każdego pola na interfejsie tworzymy properties
        public String Kod
        { get
            {
                return item.Kod;
            }
            set
            {
                item.Kod = value;
                OnPropertyChanged(() => Kod);
            }
        }
        public String Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                item.Nazwa = value;
                OnPropertyChanged(() => Nazwa);
            }
        }
        public decimal? StawkaVatZakupu
        {
            get
            {
                return item.StawkaVatZakupu;
            }
            set
            {
                item.StawkaVatZakupu = value;
                OnPropertyChanged(() => StawkaVatZakupu);
            }
        }
        public decimal? StawkaVatSprzedaży
        {
            get
            {
                return item.StawkaVatSprzedaży;
            }
            set
            {
                item.StawkaVatSprzedaży = value;
                OnPropertyChanged(() => StawkaVatSprzedaży);
            }
        }
        public decimal? Cena
        {
            get
            {
                return item.Cena;
            }
            set
            {
                item.Cena = value;
                OnPropertyChanged(() => Cena);
            }
        }
        public decimal? Marza
        {
            get
            {
                return item.Marża;
            }
            set
            {
                item.Marża = value;
                OnPropertyChanged(() => Marza);
            }
        }

        #endregion
        #region Helpers
        public  override void Save()
        {
            FakturyEntities.Towar.Add(item); // dodaje towar do lokalnej kolekcji 
            FakturyEntities.SaveChanges(); // zapisuje zmiany do bazy danych

        }
       
        #endregion
    }
}
