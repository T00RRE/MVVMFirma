using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class WszystkieReklamacjeViewModel : WszystkieViewModel<Reklamacja>
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

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Reklamacja>(fakturyEntities.Reklamacja.ToList());
        }
        #endregion
    }
}