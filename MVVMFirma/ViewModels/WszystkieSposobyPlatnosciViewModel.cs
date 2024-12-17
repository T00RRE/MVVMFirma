using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class WszystkieSposobyPlatnosciViewModel : WszystkieViewModel<SposóbPłatności>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public WszystkieSposobyPlatnosciViewModel()
            : base("Sposoby Płatności")
        {
            fakturyEntities = new Faktury2024Entities();
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<SposóbPłatności>(fakturyEntities.SposóbPłatności.ToList());
        }
        #endregion
    }
}