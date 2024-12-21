using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity;

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
        #endregion
    }
}