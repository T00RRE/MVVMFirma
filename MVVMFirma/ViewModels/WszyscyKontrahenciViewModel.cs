using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class WszyscyKontrahenciViewModel : WszystkieViewModel<KontrahentForAllView>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion

        #region Constructor
        public WszyscyKontrahenciViewModel()
            : base("Kontrahenci")
        {
            fakturyEntities = new Faktury2024Entities();
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KontrahentForAllView>(
                from kontrahent in fakturyEntities.Kontrahent
                select new KontrahentForAllView
                {
                    IdKontrahenta = kontrahent.IdKontrahenta,
                    Kod = kontrahent.Kod,
                    NIP = kontrahent.NIP,
                    Nazwa = kontrahent.Nazwa,
                    RodzajNazwa = kontrahent.Rodzaj.Nazwa,
                    AdresMiejscowosc = kontrahent.Adres.Miejscowość,
                    AdresUlica = kontrahent.Adres.Ulica,
                    AdresNrDomu = kontrahent.Adres.NrDomu,
                    AdresNrLokalu = kontrahent.Adres.NrLokalu,
                    AdresKodPocztowy = kontrahent.Adres.KodPocztowy
                }
            );
        }
        #endregion
    }
}