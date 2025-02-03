using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class NowaReklamacjaViewModel : jedenViewModel<Reklamacja>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        private ObservableCollection<PracownikForComboBox> _pracownicyList;
        public ObservableCollection<PracownikForComboBox> PracownicyList
        {
            get { return _pracownicyList; }
            set
            {
                _pracownicyList = value;
                OnPropertyChanged(() => PracownicyList);
            }
        }
        #endregion

        #region Constructor
        public NowaReklamacjaViewModel() : base("Reklamacja")
        {
            item = new Reklamacja();
            fakturyEntities = new Faktury2024Entities();
            PracownicyList = new ObservableCollection<PracownikForComboBox>(
                fakturyEntities.Pracownik.Select(pracownik => new PracownikForComboBox
                {
                    IdPracownika = pracownik.IdPracownika,
                    FullName = pracownik.Imie + " " + pracownik.Nazwisko
                }).ToList()
            );
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
        public class PracownikForComboBox
        {
            public int IdPracownika { get; set; }
            public string FullName { get; set; }
        }
        protected override string ValidateProperty(string propertyname)
        {
            switch (propertyname)
            {
                case nameof(DataReklamacji):
                    return !DataReklamacji.HasValue ? "Data reklamacji jest wymagana" : string.Empty;

                case nameof(Status):
                    return string.IsNullOrEmpty(Status) ? "Status jest wymagany" : string.Empty;

                case nameof(OpisReklamacji):
                    return string.IsNullOrEmpty(OpisReklamacji) ? "Opis reklamacji jest wymagany" : string.Empty;

                case nameof(IdPracownika):
                    return !IdPracownika.HasValue ? "Pracownik jest wymagany" : string.Empty;

                case nameof(Decyzja):
                    return string.IsNullOrEmpty(Decyzja) ? "Decyzja jest wymagana" : string.Empty;

                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}