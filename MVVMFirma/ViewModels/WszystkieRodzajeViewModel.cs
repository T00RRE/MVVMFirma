using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class WszystkieRodzajeViewModel : WszystkieViewModel<Rodzaj>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion

        #region Constructor
        public WszystkieRodzajeViewModel()
            : base("Rodzaje")
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
            List = new ObservableCollection<Rodzaj>(fakturyEntities.Rodzaj.ToList());
        }
        //public override void ShowAddWindow()
        //{
        //    var nowyRodzaj = new NowyRodzajViewModel();
        //    EventAggregator.PublishWorkspaceViewModel(nowyRodzaj);
        //}\
        protected override void Delete()
        {
            var rekordDoUsuniecia = fakturyEntities.Rodzaj.FirstOrDefault(x => x.IdRodzaju == WybraneId);
            if (rekordDoUsuniecia != null)
            {
                fakturyEntities.Rodzaj.Remove(rekordDoUsuniecia);
                fakturyEntities.SaveChanges();
            }
        }
        #endregion
    }
}