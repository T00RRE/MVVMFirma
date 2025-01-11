using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities;
using MVVMFirma.Helper;
using System.Windows.Input;
using Microsoft.Win32;
using MVVMFirma.Models.EntitiesForView; // dodajemy nowy using

namespace MVVMFirma.ViewModels
{
    // Zmieniamy typ generyczny z Faktura na FakturaForAllView
    public class WszystkieFakturyViewModel : WszystkieViewModel<FakturaForAllView>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public WszystkieFakturyViewModel()
            : base("Faktury")
        {
            fakturyEntities = new Faktury2024Entities();
        }
        #endregion


        #region Sort And Find
        //tu decydujemy po czym sortować
        public override List<string> GetCombobocSortList()
        {
            return new List<string> { "Data Wystawienia", "Termin Płatności", "Sposób Płatności" };
        }
        //a tu decydujemy po czym wyszukiwać
        public override void Sort()
        {
            if (SortField == "Data Wystawienia")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.DataWystawienia));
            if (SortField == "Termin Płatności")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.TerminPlatosci));
            if (SortField == "Sposób Płatności")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.SposobuPlatnosciNazwa));
        }
        //tu decydujemy po czym wyszukiwać 
        public override List<string> GetCombobocFindList()
        {
            return new List<string> { "Numer", "NIP", "Nazwa Kontrahenta" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Numer")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.Numer != null && item.Numer.StartsWith(FindTextBox)));
            if (FindField == "NIP")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.KontrahentNIP != null && item.KontrahentNIP.StartsWith(FindTextBox)));
            if (FindField == "Nazwa Kontrahenta")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.KontrahentNazwa != null && item.KontrahentNazwa.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<FakturaForAllView>(
                from faktura in fakturyEntities.Faktura
                join sposobPlatnosci in fakturyEntities.SposóbPłatności
                on faktura.IdSposobuPłatności equals sposobPlatnosci.IdSposobuPłatności
                select new FakturaForAllView
                {
                    IdFaktury = faktura.IdFaktury,
                    Numer = faktura.Numer,
                    CzyZatwierdzona = faktura.CzyZatwierdzona ?? false,
                    DataWystawienia = faktura.DataWystawienia,
                    KontrahentNIP = faktura.Kontrahent.NIP,
                    KontrahentNazwa = faktura.Kontrahent.Nazwa,
                    TerminPlatosci = faktura.TerminPłatności,
                    SposobuPlatnosciNazwa = sposobPlatnosci.Nazwa  // używamy joinowanej tabeli
                }
            );
        }
        //public override void ShowAddWindow()
        //{
        //    var nowaFaktura = new NowaFakturaViewModel();
        //    EventAggregator.PublishWorkspaceViewModel(nowaFaktura);
        //}
        #endregion
    }
}