using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace MVVMFirma.ViewModels
{
    public class WszystkiePromocjeViewModel : WszystkieViewModel<Promocja>
    {
        #region Constructor
        public WszystkiePromocjeViewModel() : base("Promocje")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Promocja>
            (
                from promocja in fakturyEntities.Promocja
                select promocja
            );
        }
        #endregion

        #region Sort and Find
        public override List<string> GetCombobocSortList()
        {
            return new List<string> { "Nazwa promocji", "Data rozpoczęcia", "Data zakończenia", "Wysokość rabatu" };
        }

        public override List<string> GetCombobocFindList()
        {
            return new List<string> { "Nazwa promocji", "Opis promocji" };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa promocji":
                    List = new ObservableCollection<Promocja>(List.OrderBy(item => item.NazwaPromocji));
                    break;
                case "Data rozpoczęcia":
                    List = new ObservableCollection<Promocja>(List.OrderBy(item => item.DataRozpoczecia));
                    break;
                case "Data zakończenia":
                    List = new ObservableCollection<Promocja>(List.OrderBy(item => item.DataZakonczenia));
                    break;
                case "Wysokość rabatu":
                    List = new ObservableCollection<Promocja>(List.OrderBy(item => item.WysokoscRabatu));
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
                    case "Nazwa promocji":
                        List = new ObservableCollection<Promocja>(List.Where(item => item.NazwaPromocji.Contains(FindTextBox)));
                        break;
                    case "Opis promocji":
                        List = new ObservableCollection<Promocja>(List.Where(item => item.OpisPromocji.Contains(FindTextBox)));
                        break;
                }
            }
        }
        #endregion
    }
}