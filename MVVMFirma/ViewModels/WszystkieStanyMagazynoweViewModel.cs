using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class WszystkieStanyMagazynoweViewModel : WszystkieViewModel<StanMagazynowy>
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

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<StanMagazynowy>(fakturyEntities.StanMagazynowy.ToList());
        }
        #endregion
    }
}