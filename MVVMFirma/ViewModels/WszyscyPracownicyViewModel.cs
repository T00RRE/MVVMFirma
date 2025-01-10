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
            return null;
        }
        //a tu decydujemy po czym wyszukiwać
        public override void Sort()
        {

        }
        //tu decydujemy po czym wyszukiwać 
        public override List<string> GetCombobocFindList()
        {
            return null;
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {

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
        #endregion
    }
}