﻿using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowyStatusViewModel : jedenViewModel<Status>
    {
        #region Konstruktor
        public NowyStatusViewModel() : base("Status")
        {
            item = new Status();
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
            FakturyEntities.Status.Add(item);
            FakturyEntities.SaveChanges();
        }
        #endregion
    }
}