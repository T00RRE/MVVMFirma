using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;

namespace MVVMFirma.ViewModels
{
    public class NowaReklamacjaViewModel : jedenViewModel<Reklamacja>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion

        #region Constructor
        public NowaReklamacjaViewModel()
            : base("Reklamacja")
        {
            item = new Reklamacja();
            fakturyEntities = new Faktury2024Entities();
        }
        #endregion

        #region Properties
        public DateTime? DataReklamacji
        {
            get
            {
                return item.DataReklamacji;
            }
            set
            {
                if (value != item.DataReklamacji)
                {
                    item.DataReklamacji = value.HasValue ? value.Value : DateTime.Now; // jeśli value jest null, ustawiamy aktualną datę
                                                                                       // lub
                                                                                       // item.DataReklamacji = value.GetValueOrDefault(DateTime.Now); // alternatywny zapis
                    OnPropertyChanged(() => DataReklamacji);
                }
            }
        }

        public string Status
        {
            get
            {
                return item.Status;
            }
            set
            {
                if (value != item.Status)
                {
                    item.Status = value;
                    OnPropertyChanged(() => Status);
                }
            }
        }

        public string OpisReklamacji
        {
            get
            {
                return item.OpisReklamacji;
            }
            set
            {
                if (value != item.OpisReklamacji)
                {
                    item.OpisReklamacji = value;
                    OnPropertyChanged(() => OpisReklamacji);
                }
            }
        }

        public int? IdPracownika
        {
            get
            {
                return item.IdPracownika;
            }
            set
            {
                if (value != item.IdPracownika)
                {
                    item.IdPracownika = value;
                    OnPropertyChanged(() => IdPracownika);
                }
            }
        }

        public string Decyzja
        {
            get
            {
                return item.Decyzja;
            }
            set
            {
                if (value != item.Decyzja)
                {
                    item.Decyzja = value;
                    OnPropertyChanged(() => Decyzja);
                }
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            fakturyEntities.Reklamacja.Add(item);
            fakturyEntities.SaveChanges();
        }
        #endregion
    }
}