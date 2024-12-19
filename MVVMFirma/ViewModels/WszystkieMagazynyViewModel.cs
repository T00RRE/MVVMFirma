using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class WszystkieMagazynyViewModel : WszystkieViewModel<Magazyn>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion

        #region Constructor
        public WszystkieMagazynyViewModel()
            : base("Magazyny")
        {
            fakturyEntities = new Faktury2024Entities();
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Magazyn>(fakturyEntities.Magazyn.ToList());
        }
        #endregion
    }
}