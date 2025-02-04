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
        #region Sort And Find
        //tu decydujemy po czym sortować
        public override List<string> GetCombobocSortList()
        {
            return new List<string> { "kod", "nazwa", "cena" };
        }
        //a tu decydujemy po czym wyszukiwać
        public override void Sort()
        {
            if (SortField == "kod")
                List = new ObservableCollection<Towar>(List.OrderBy(item => item.Kod));
            if (SortField == "nazwa")
                List = new ObservableCollection<Towar>(List.OrderBy(item => item.Nazwa));
            if (SortField == "cena")
                List = new ObservableCollection<Towar>(List.OrderBy(item => item.Cena));
        }
        //tu decydujemy po czym wyszukiwać 
        public override List<string> GetCombobocFindList()
        {
            return new List<string> { "kod", "nazwa" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if(FindField == "nazwa")
                List = new ObservableCollection<Towar>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "kod")
                List = new ObservableCollection<Towar>(List.Where(item => item.Kod != null && item.Kod.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        // metoda load pobiera wszystkie towary z bazy danych;
        public override void Load()
        {
            
            List = new ObservableCollection<Towar>(fakturyEntities.Towar.ToList()); // z bazy danych którą reprezentuje " fakturyEntities pobieram Towar i wszystkie rekordy zamieniam na liste
        }
        //public override void ShowAddWindow()
        //{
        //    var nowyTowar = new NowyTowarViewModel();
        //    EventAggregator.PublishWorkspaceViewModel(nowyTowar);
        //}
        protected override void Delete()
        {
            var rekordDoUsuniecia = fakturyEntities.Towar.FirstOrDefault(x => x.IdTowaru == WybraneId);
            if (rekordDoUsuniecia != null)
            {
                fakturyEntities.Towar.Remove(rekordDoUsuniecia);
                fakturyEntities.SaveChanges();
            }
        }
        #endregion
    }
}