using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class WszystkieReklamacjeViewModel : WszystkieViewModel<ReklamacjaForAllView>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion

        #region Constructor
        public WszystkieReklamacjeViewModel()
            : base("Reklamacje")
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
            return new List<string> { "Status", "Pracownik", "Data" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Status")
                List = new ObservableCollection<ReklamacjaForAllView>(List.Where(item => item.Status != null && item.Status.StartsWith(FindTextBox)));
            if (FindField == "Pracownik")
                List = new ObservableCollection<ReklamacjaForAllView>(List.Where(item => item.PracownikImie != null && item.PracownikImie.StartsWith(FindTextBox)));
            //dodać date z date pickerem
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ReklamacjaForAllView>(
                from reklamacja in fakturyEntities.Reklamacja
                select new ReklamacjaForAllView
                {
                    IdReklamacji = reklamacja.IdReklamacji,
                    Status = reklamacja.Status,
                    DataReklamacji = reklamacja.DataReklamacji,
                    OpisReklamacji = reklamacja.OpisReklamacji,
                    PracownikImie = reklamacja.Pracownik.Imie,
                    PracownikNazwisko = reklamacja.Pracownik.Nazwisko,
                    Decyzja = reklamacja.Decyzja
                }
            );
        }
        //public override void ShowAddWindow()
        //{
        //    var nowaReklamacja = new NowaReklamacjaViewModel();
        //    EventAggregator.PublishWorkspaceViewModel(nowaReklamacja);
        //}
        #endregion
    }
}