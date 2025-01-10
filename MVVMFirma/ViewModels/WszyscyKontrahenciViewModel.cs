using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Views;
using System.Collections.Generic;
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
        #region Properties
        //do tego pola i propertisa zostanie przypisany kontrahent kliknięty na liscie 
        private KontrahentForAllView _WybranyKontrahent;
        public KontrahentForAllView WybranyKontrahent
        {
            get
            {
                return _WybranyKontrahent;
            }
            set
            {
                _WybranyKontrahent = value;
                if (_WybranyKontrahent != null)
                {
                    // Znajdź odpowiadający Kontrahent w bazie danych
                    var kontrahent = fakturyEntities.Kontrahent
                        .FirstOrDefault(k => k.IdKontrahenta == _WybranyKontrahent.IdKontrahenta);

                    // Wyślij faktycznego Kontrahenta
                    if (kontrahent != null)
                    {
                        Messenger.Default.Send(kontrahent);
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        #region Sort And Find
        //tu decydujemy po czym sortować
        public override List<string> GetCombobocSortList()
        {
            return null;
        }
        //a tu decydujemy po czym wyszukiwać
        public override void Sort()
        {

        }
        //tu decydujemy po czym wyszukiwać 
        public override List<string> GetCombobocFindList()
        {
            return null;
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {

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
        //public override void ShowAddWindow()
        //{
        //    var nowyKontrahent = new NowyKontrahentViewModel();
        //    EventAggregator.PublishWorkspaceViewModel(nowyKontrahent);
        //}
        #endregion
    }
}