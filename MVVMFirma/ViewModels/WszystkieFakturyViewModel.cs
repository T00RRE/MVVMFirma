﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities;
using MVVMFirma.Helper;
using System.Windows.Input;
using Microsoft.Win32;


namespace MVVMFirma.ViewModels
{
    public class WszystkieFakturyViewModel : WszystkieViewModel<Faktura> // bo wszystkie zakładki dziedziczą po WVM
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion
        #region Properties

        #endregion
        #region Constructor

       
        public WszystkieFakturyViewModel()
            :base("Faktury")
        {
            fakturyEntities = new Faktury2024Entities();
        }
        #endregion
        #region Helpers
        public override void Load()
        {

            List = new ObservableCollection<Faktura>(fakturyEntities.Faktura.ToList()); // z bazy danych którą reprezentuje " fakturyEntities pobieram Towar i wszystkie rekordy zamieniam na liste
        }
        #endregion
    }
}
