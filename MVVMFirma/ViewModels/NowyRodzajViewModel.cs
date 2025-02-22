﻿using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class NowyRodzajViewModel : jedenViewModel<Rodzaj>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion

        #region Constructor
        public NowyRodzajViewModel()
            : base("Rodzaj")
        {
            item = new Rodzaj();
            fakturyEntities = new Faktury2024Entities();
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
                if (value != item.Nazwa)
                {
                    item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
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
                if (value != item.Opis)
                {
                    item.Opis = value;
                    OnPropertyChanged(() => Opis);
                }
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            fakturyEntities.Rodzaj.Add(item);
            fakturyEntities.SaveChanges();
        }
        protected override string ValidateProperty(string propertyname)
        {
            switch (propertyname)
            {
                case nameof(Nazwa):
                    return string.IsNullOrEmpty(Nazwa) ? "Nazwa jest wymagana" : string.Empty;

                case nameof(Opis):
                    return string.IsNullOrEmpty(Opis) ? "Opis jest wymagany" : string.Empty;

                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}