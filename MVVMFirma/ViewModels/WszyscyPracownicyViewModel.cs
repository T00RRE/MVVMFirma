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
    public class WszyscyPracownicyViewModel : WszystkieViewModel<Pracownik>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public WszyscyPracownicyViewModel()
            : base("Pracownicy")
        {
            fakturyEntities = new Faktury2024Entities();
        }
        #endregion
        #region Sort And Find
        //tu decydujemy po czym sortować
        public override List<string> GetCombobocSortList()
        {
            return new List<string> {  "Stanowisko" , "Pensja rosnąco","Pensja malejąco" };
        }
        //a tu decydujemy po czym wyszukiwać
        public override void Sort()
        {
            if (SortField == "Stanowisko")
                List = new ObservableCollection<Pracownik>(List.OrderBy(item => item.Stanowisko));
            if (SortField == "Pensja rosnąco")
                List = new ObservableCollection<Pracownik>(List.OrderBy(item => item.Pensja));
            if (SortField == "Pensja malejąco")
                List = new ObservableCollection<Pracownik>(List.OrderByDescending(item => item.Pensja));
        }
        //tu decydujemy po czym wyszukiwać 
        public override List<string> GetCombobocFindList()
        {
            return new List<string> { "Nazwisko", "Pesel","Stanowisko" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Nazwisko")
                List = new ObservableCollection<Pracownik>(List.Where(item => item.Nazwisko != null && item.Nazwisko.StartsWith(FindTextBox)));
            if (FindField == "Pesel")
                List = new ObservableCollection<Pracownik>(List.Where(item => item.PESEL != null && item.PESEL.StartsWith(FindTextBox)));
            if (FindField == "Stanowisko")
                List = new ObservableCollection<Pracownik>(List.Where(item => item.Stanowisko != null && item.Stanowisko.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Pracownik>(fakturyEntities.Pracownik.ToList());
        }
        //public override void ShowAddWindow()
        //{
        //    var nowyPracownik = new NowyRodzajViewModel();
        //    EventAggregator.PublishWorkspaceViewModel(nowyPracownik);
        //}
        protected override void Delete()
        {
            var rekordDoUsuniecia = fakturyEntities.Pracownik.FirstOrDefault(x => x.IdPracownika == WybraneId);
            if (rekordDoUsuniecia != null)
            {
                fakturyEntities.Pracownik.Remove(rekordDoUsuniecia);
                fakturyEntities.SaveChanges();
            }
        }
        #endregion
    }
}