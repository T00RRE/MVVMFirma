using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
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

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Rodzaj>(fakturyEntities.Rodzaj.ToList());
        }
        public override void ShowAddWindow()
        {
            var nowyRodzaj = new NowyRodzajViewModel();
            EventAggregator.PublishWorkspaceViewModel(nowyRodzaj);
        }
        #endregion
    }
}