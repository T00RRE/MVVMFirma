using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowySposobPlatnosciViewModel : jedenViewModel<SposóbPłatności>
    {
        #region Konstruktor
        public NowySposobPlatnosciViewModel() : base("Sposób Płatności")
        {
            item = new SposóbPłatności();
        }
        #endregion

        #region Properties
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                item.Nazwa = value;
                OnPropertyChanged(() => Nazwa);
            }
        }

        public string Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                item.Opis = value;
                OnPropertyChanged(() => Opis);
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            FakturyEntities.SposóbPłatności.Add(item);
            FakturyEntities.SaveChanges();
        }
        #endregion
    }
}