using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace MVVMFirma.ViewModels
{
    public class WszystkieStanyMagazynoweViewModel : WszystkieViewModel<StanMagazynowyForAllView>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion

        #region Constructor
        public WszystkieStanyMagazynoweViewModel()
            : base("Stany Magazynowe")
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
            List = new ObservableCollection<StanMagazynowyForAllView>(
                fakturyEntities.StanMagazynowy.Select(stan => new StanMagazynowyForAllView
                {
                    IdStanu = stan.IdStanu,
                    TowarNazwa = stan.Towar.Nazwa,
                    MagazynNazwa = stan.Magazyn.Nazwa,
                    Ilosc = stan.Ilosc,
                    MinimalnyPoziom = stan.MinimalnyPoziom,
                    MaxymalnyPoziom = stan.MaxymalnyPoziom
                }).ToList()
            );
        }
        //public override void ShowAddWindow()
        //{
        //    var nowyStanMagazynowy = new NowyStanMagazynowyViewModel();
        //    EventAggregator.PublishWorkspaceViewModel(nowyStanMagazynowy);
        //}
        protected override void Delete()
        {
            var rekordDoUsuniecia = fakturyEntities.StanMagazynowy.FirstOrDefault(x => x.IdStanu == WybraneId);
            if (rekordDoUsuniecia != null)
            {
                fakturyEntities.StanMagazynowy.Remove(rekordDoUsuniecia);
                fakturyEntities.SaveChanges();
            }
        }
        #endregion
    }
}