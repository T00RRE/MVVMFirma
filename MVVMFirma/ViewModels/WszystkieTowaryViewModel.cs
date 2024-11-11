using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities;
using MVVMFirma.Helper;
using System.Windows.Input;
using Microsoft.Win32;

namespace MVVMFirma.ViewModels
{
    //to jest klasa która dostarcza dane do widoku wyswietlającego wszystkie towary
    public class WszystkieTowaryViewModel : WszystkieViewModel<Towar>
    {
       
        #region Constructor
        public WszystkieTowaryViewModel()
            :base("Towary")
        { 
        }
        #endregion
        #region Helpers
        // metoda load pobiera wszystkie towary z bazy danych;
        public override void Load()
        {
            
            List = new ObservableCollection<Towar>(fakturyEntities.Towar.ToList()); // z bazy danych którą reprezentuje " fakturyEntities pobieram Towar i wszystkie rekordy zamieniam na liste
        }
        #endregion
    }
}