using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class NowaDostawaViewModel : jedenViewModel<Dostawa>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion

        #region Constructor
        public NowaDostawaViewModel() : base("Dostawa")
        {
            item = new Dostawa();
            fakturyEntities = new Faktury2024Entities();
            item.DataDostawy = DateTime.Now;
        }
        #endregion

        #region Properties
        public DateTime DataDostawy
        {
            get
            {
                return item.DataDostawy;
            }
            set
            {
                item.DataDostawy = value;
                OnPropertyChanged(() => DataDostawy);
            }
        }

        public int? IdDostawcy
        {
            get
            {
                return item.IdDostawcy;
            }
            set
            {
                item.IdDostawcy = value;
                OnPropertyChanged(() => IdDostawcy);
            }
        }

        public string NumerListuPrzewozowego
        {
            get
            {
                return item.NumerListuPrzewozowego;
            }
            set
            {
                item.NumerListuPrzewozowego = value;
                OnPropertyChanged(() => NumerListuPrzewozowego);
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
                item.Status = value;
                OnPropertyChanged(() => Status);
            }
        }

        public string UwagiBastian
        {
            get
            {
                return item.UwagiBastian;
            }
            set
            {
                item.UwagiBastian = value;
                OnPropertyChanged(() => UwagiBastian);
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            fakturyEntities.Dostawa.Add(item);
            fakturyEntities.SaveChanges();
        }

        protected override string ValidateProperty(string propertyname)
        {
            switch (propertyname)
            {
                case nameof(DataDostawy):
                    if (DateTime.MinValue == DataDostawy)
                        return "Data dostawy jest wymagana";
                    if (DataDostawy < DateTime.Now)
                        return "Data dostawy nie może być wcześniejsza niż dzisiaj";
                    return string.Empty;

                case nameof(NumerListuPrzewozowego):
                    return string.IsNullOrEmpty(NumerListuPrzewozowego) ?
                        "Numer listu przewozowego jest wymagany" : string.Empty;

                case nameof(Status):
                    return string.IsNullOrEmpty(Status) ?
                        "Status jest wymagany" : string.Empty;

                case nameof(IdDostawcy):
                    return !IdDostawcy.HasValue ?
                        "ID dostawcy jest wymagane" : string.Empty;

                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}