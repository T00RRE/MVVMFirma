using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
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