using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace MVVMFirma.ViewModels
{
    public class WszystkieDostawyViewModel : WszystkieViewModel<Dostawa>
    {
        #region Constructor
        public WszystkieDostawyViewModel() : base("Dostawy")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Dostawa>
            (
                from dostawa in fakturyEntities.Dostawa
                select dostawa
            );
        }
        #endregion

        #region Sort and Find
        public override List<string> GetCombobocSortList()
        {
            return new List<string>
            {
                "Data dostawy",
                "Numer listu przewozowego",
                "Status",
                "Dostawca"
            };
        }

        public override List<string> GetCombobocFindList()
        {
            return new List<string>
            {
                "Numer listu przewozowego",
                "Status",
                "Uwagi"
            };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "Data dostawy":
                    List = new ObservableCollection<Dostawa>(List.OrderBy(item => item.DataDostawy));
                    break;
                case "Numer listu przewozowego":
                    List = new ObservableCollection<Dostawa>(List.OrderBy(item => item.NumerListuPrzewozowego));
                    break;
                case "Status":
                    List = new ObservableCollection<Dostawa>(List.OrderBy(item => item.Status));
                    break;
                case "Dostawca":
                    List = new ObservableCollection<Dostawa>(List.OrderBy(item => item.IdDostawcy));
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
                    case "Numer listu przewozowego":
                        List = new ObservableCollection<Dostawa>(List.Where(item =>
                            item.NumerListuPrzewozowego.Contains(FindTextBox)));
                        break;
                    case "Status":
                        List = new ObservableCollection<Dostawa>(List.Where(item =>
                            item.Status.Contains(FindTextBox)));
                        break;
                    case "Uwagi":
                        List = new ObservableCollection<Dostawa>(List.Where(item =>
                            item.UwagiBastian.Contains(FindTextBox)));
                        break;
                }
            }
        }
        #endregion
    }
}