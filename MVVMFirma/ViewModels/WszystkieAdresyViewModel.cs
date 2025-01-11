using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class WszystkieAdresyViewModel : WszystkieViewModel<Adres>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion

        #region Constructor
        public WszystkieAdresyViewModel()
            : base("Adresy")
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
            return new List<string> { "Miejscowość"};
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Miejscowość")
                List = new ObservableCollection<Adres>(List.Where(item => item.Miejscowość != null && item.Miejscowość.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Adres>(fakturyEntities.Adres.ToList());
        }
        //public override void ShowAddWindow()
        //{
        //    var nowyAdres = new NowyAdresViewModel();
        //    EventAggregator.PublishWorkspaceViewModel(nowyAdres);
        //}
        #endregion
    }
}