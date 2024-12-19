using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class NowyKontrahentViewModel : jedenViewModel<Kontrahent>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion

        #region Constructor
        public NowyKontrahentViewModel()
            : base("Kontrahent")
        {
            item = new Kontrahent();
            fakturyEntities = new Faktury2024Entities();
        }
        #endregion

        #region Properties
        public string Kod
        {
            get
            {
                return item.Kod;
            }
            set
            {
                if (value != item.Kod)
                {
                    item.Kod = value;
                    OnPropertyChanged(() => Kod);
                }
            }
        }

        public string NIP
        {
            get
            {
                return item.NIP;
            }
            set
            {
                if (value != item.NIP)
                {
                    item.NIP = value;
                    OnPropertyChanged(() => NIP);
                }
            }
        }

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

        public int? IdRodzaju
        {
            get
            {
                return item.IdRodzaju;
            }
            set
            {
                if (value != item.IdRodzaju)
                {
                    item.IdRodzaju = value;
                    OnPropertyChanged(() => IdRodzaju);
                }
            }
        }

        public int? IdStatusu
        {
            get
            {
                return item.IdStatusu;
            }
            set
            {
                if (value != item.IdStatusu)
                {
                    item.IdStatusu = value;
                    OnPropertyChanged(() => IdStatusu);
                }
            }
        }

        public int? IdAdresu
        {
            get
            {
                return item.IdAdresu;
            }
            set
            {
                if (value != item.IdAdresu)
                {
                    item.IdAdresu = value;
                    OnPropertyChanged(() => IdAdresu);
                }
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            fakturyEntities.Kontrahent.Add(item);
            fakturyEntities.SaveChanges();
        }
        #endregion
    }
}