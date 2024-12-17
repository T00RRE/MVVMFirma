using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class WszystkieStatusyViewModel : WszystkieViewModel<Status>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion
        #region Properties

        #endregion
        #region Constructor


        public WszystkieStatusyViewModel()
            : base("Statusy")
        {
            fakturyEntities = new Faktury2024Entities();
        }
        #endregion
        #region Helpers
        public override void Load()
        {

            List = new ObservableCollection<Status>(fakturyEntities.Status.ToList()); // z bazy danych którą reprezentuje " fakturyEntities pobieram Towar i wszystkie rekordy zamieniam na liste
        }
        #endregion
    }
}