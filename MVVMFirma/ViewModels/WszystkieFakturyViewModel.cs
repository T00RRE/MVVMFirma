﻿using System;
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

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<FakturaForAllView>(
                from faktura in fakturyEntities.Faktura
                select new FakturaForAllView
                {
                    IdFaktury = faktura.IdFaktury,
                    Numer = faktura.Numer,
                    CzyZatwierdzona = faktura.CzyZatwierdzona ?? false,
                    DataWystawienia = faktura.DataWystawienia ?? DateTime.Now,
                    
                    KontrahentNIP = faktura.Kontrahent.NIP,
                    KontrahentNazwa = faktura.Kontrahent.Nazwa,
                    TerminPlatosci = faktura.TerminPłatności ?? DateTime.Now,
                    
                    SposobuPlatnosciNazwa = fakturyEntities.SposóbPłatności
                        .Where(sp => sp.IdSposobuPłatności == faktura.IdSposobuPłatności)
                        .Select(sp => sp.Nazwa)
                        .FirstOrDefault()
                }
            );
        }
        #endregion
    }
}