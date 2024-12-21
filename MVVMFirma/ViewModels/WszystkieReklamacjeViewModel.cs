using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class WszystkieReklamacjeViewModel : WszystkieViewModel<ReklamacjaForAllView>
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
            List = new ObservableCollection<ReklamacjaForAllView>(
                from reklamacja in fakturyEntities.Reklamacja
                select new ReklamacjaForAllView
                {
                    IdReklamacji = reklamacja.IdReklamacji,
                    Status = reklamacja.Status,
                    DataReklamacji = reklamacja.DataReklamacji,
                    OpisReklamacji = reklamacja.OpisReklamacji,
                    PracownikImie = reklamacja.Pracownik.Imie,
                    PracownikNazwisko = reklamacja.Pracownik.Nazwisko,
                    Decyzja = reklamacja.Decyzja
                }
            );
        }
        #endregion
    }
}