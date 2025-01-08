using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity; // dodaj ten using

namespace MVVMFirma.ViewModels
{
    public class WszystkieMagazynyViewModel : WszystkieViewModel<MagazynForAllView>
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
            List = new ObservableCollection<MagazynForAllView>(
                fakturyEntities.Magazyn.Select(magazyn => new MagazynForAllView
                {
                    IdMagazynu = magazyn.IdMagazynu,
                    Nazwa = magazyn.Nazwa,
                    Lokalizacja = magazyn.Lokalizacja,
                    Pojemnosc = magazyn.Pojemnosc,
                    Status = magazyn.Status
                }).ToList()
            );
        }

        #endregion
    }
}