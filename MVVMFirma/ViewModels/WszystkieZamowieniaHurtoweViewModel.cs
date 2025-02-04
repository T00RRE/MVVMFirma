using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace MVVMFirma.ViewModels
{
    public class WszystkieZamowieniaHurtoweViewModel : WszystkieViewModel<ZamowienieHurtowe>
    {
        #region Constructor
        public WszystkieZamowieniaHurtoweViewModel() : base("ZamowieniaHurtowe")
        {
            Load();
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZamowienieHurtowe>
            (
                from zamowienie in fakturyEntities.ZamowienieHurtowe
                select zamowienie
            );
        }
        #endregion

        #region Sort and Find
        public override List<string> GetCombobocSortList()
        {
            return new List<string>
            {
                "Data zamówienia",
                "Termin realizacji",
                "Status",
                "Wartość zamówienia"
            };
        }

        public override List<string> GetCombobocFindList()
        {
            return new List<string>
            {
                "Status",
                "Wartość zamówienia",
                "Kontrahent"
            };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "Data zamówienia":
                    List = new ObservableCollection<ZamowienieHurtowe>(List.OrderBy(item => item.DataZamowienia));
                    break;
                case "Termin realizacji":
                    List = new ObservableCollection<ZamowienieHurtowe>(List.OrderBy(item => item.TerminRealizacji));
                    break;
                case "Status":
                    List = new ObservableCollection<ZamowienieHurtowe>(List.OrderBy(item => item.Status));
                    break;
                case "Wartość zamówienia":
                    List = new ObservableCollection<ZamowienieHurtowe>(List.OrderBy(item => item.WartoscZamowienia));
                    break;
            }
        }

        public override void Find()
        {
            Load();
            if (!string.IsNullOrEmpty(FindTextBox))
            {
                switch (FindField)
                {
                    case "Status":
                        List = new ObservableCollection<ZamowienieHurtowe>(List.Where(item =>
                            item.Status.Contains(FindTextBox)));
                        break;
                    case "Wartość zamówienia":
                        if (decimal.TryParse(FindTextBox, out decimal wartosc))
                        {
                            List = new ObservableCollection<ZamowienieHurtowe>(List.Where(item =>
                                item.WartoscZamowienia == wartosc));
                        }
                        break;
                    case "Kontrahent":
                        List = new ObservableCollection<ZamowienieHurtowe>(List.Where(item =>
                            item.Kontrahent.Nazwa.Contains(FindTextBox) ||
                            item.Kontrahent.NIP.Contains(FindTextBox)));
                        break;
                }
            }
        }
        protected override void Delete()
        {
            var rekordDoUsuniecia = fakturyEntities.ZamowienieHurtowe.FirstOrDefault(x => x.IdZamowienia == WybraneId);
            if (rekordDoUsuniecia != null)
            {
                fakturyEntities.ZamowienieHurtowe.Remove(rekordDoUsuniecia);
                fakturyEntities.SaveChanges();
            }
        }
        #endregion
    }
}