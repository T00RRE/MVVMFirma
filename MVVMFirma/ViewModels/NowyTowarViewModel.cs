using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowyTowarViewModel : WorkspaceViewModel
    {
        #region DB
        private FakturyEntities FakturyEntities;
        #endregion
        #region Item
        private Towar towar;
        #endregion
        #region Command 
        //to jest komenda, która zostanie podpieta pod przycisk zapisz i zamknij i ona wywola funkcje SaveAndClose
        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                return _SaveCommand;

                }
               
                
        }
        #endregion
        #region Konstruktor
        public NowyTowarViewModel()
        {
            base.DisplayName = "Towar";
            FakturyEntities = new FakturyEntities();
            towar = new Towar();
        }
        #endregion
        #region Properties
        //dla każdego pola na interfejsie tworzymy properties
        public String Kod
        { get
            {
                return towar.Kod;
            }
            set
            {
                towar.Kod = value;
                OnPropertyChanged(() => Kod);
            }
        }
        public String Nazwa
        {
            get
            {
                return towar.Nazwa;
            }
            set
            {
                towar.Nazwa = value;
                OnPropertyChanged(() => Nazwa);
            }
        }
        public decimal? StawkaVatZakupu
        {
            get
            {
                return towar.StawkaVatZakupu;
            }
            set
            {
                towar.StawkaVatZakupu = value;
                OnPropertyChanged(() => StawkaVatZakupu);
            }
        }
        public decimal? StawkaVatSprzedaży
        {
            get
            {
                return towar.StawkaVatSprzedaży;
            }
            set
            {
                towar.StawkaVatSprzedaży = value;
                OnPropertyChanged(() => StawkaVatSprzedaży);
            }
        }
        public decimal? Cena
        {
            get
            {
                return towar.Cena;
            }
            set
            {
                towar.Cena = value;
                OnPropertyChanged(() => Cena);
            }
        }
        public decimal? Marza
        {
            get
            {
                return towar.Marża;
            }
            set
            {
                towar.Marża = value;
                OnPropertyChanged(() => Marza);
            }
        }

        #endregion
        #region Helpers
        public void Save()
        {
            FakturyEntities.Towar.Add(towar); // dodaje towar do lokalnej kolekcji 
            FakturyEntities.SaveChanges(); // zapisuje zmiany do bazy danych

        }
        public void SaveAndClose()
        {
        Save();
            base.OnRequestClose(); //zamkniecie zakladki
        }
        #endregion
    }
}
