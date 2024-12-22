// NowyStanMagazynowyViewModel:
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class NowyStanMagazynowyViewModel : jedenViewModel<StanMagazynowy>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        private ObservableCollection<TowarForComboBox> _towaryList;
        private ObservableCollection<MagazynForComboBox> _magazynyList;
        #endregion

        #region Constructor
        public NowyStanMagazynowyViewModel() : base("Stan Magazynowy")
        {
            item = new StanMagazynowy();
            fakturyEntities = new Faktury2024Entities();

            TowaryList = new ObservableCollection<TowarForComboBox>(
                fakturyEntities.Towar.Select(towar => new TowarForComboBox
                {
                    IdTowaru = towar.IdTowaru,
                    NazwaTowaru = towar.Nazwa
                }).ToList()
            );

            MagazynyList = new ObservableCollection<MagazynForComboBox>(
                fakturyEntities.Magazyn.Select(magazyn => new MagazynForComboBox
                {
                    IdMagazynu = magazyn.IdMagazynu,
                    NazwaMagazynu = magazyn.Nazwa
                }).ToList()
            );
        }
        #endregion

        #region Properties
        public int? IdTowaru
        {
            get
            {
                return item.IdTowaru;
            }
            set
            {
                if (value != item.IdTowaru)
                {
                    item.IdTowaru = value;
                    OnPropertyChanged(() => IdTowaru);
                }
            }
        }

        public int? IdMagazynu
        {
            get
            {
                return item.IdMagazynu;
            }
            set
            {
                if (value != item.IdMagazynu)
                {
                    item.IdMagazynu = value;
                    OnPropertyChanged(() => IdMagazynu);
                }
            }
        }

        public int IdStanu
        {
            get
            {
                return item.IdStanu;
            }
            set
            {
                if (value != item.IdStanu)
                {
                    item.IdStanu = value;
                    OnPropertyChanged(() => IdStanu);
                }
            }
        }

        public int Ilosc
        {
            get
            {
                return item.Ilosc;
            }
            set
            {
                if (value != item.Ilosc)
                {
                    item.Ilosc = value;
                    OnPropertyChanged(() => Ilosc);
                }
            }
        }

        public int? MinimalnyPoziom
        {
            get
            {
                return item.MinimalnyPoziom;
            }
            set
            {
                if (value != item.MinimalnyPoziom)
                {
                    item.MinimalnyPoziom = value;
                    OnPropertyChanged(() => MinimalnyPoziom);
                }
            }
        }

        public int? MaxymalnyPoziom
        {
            get
            {
                return item.MaxymalnyPoziom;
            }
            set
            {
                if (value != item.MaxymalnyPoziom)
                {
                    item.MaxymalnyPoziom = value;
                    OnPropertyChanged(() => MaxymalnyPoziom);
                }
            }
        }
        public ObservableCollection<TowarForComboBox> TowaryList
        {
            get { return _towaryList; }
            set
            {
                _towaryList = value;
                OnPropertyChanged(() => TowaryList);
            }
        }

        public ObservableCollection<MagazynForComboBox> MagazynyList
        {
            get { return _magazynyList; }
            set
            {
                _magazynyList = value;
                OnPropertyChanged(() => MagazynyList);
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            fakturyEntities.StanMagazynowy.Add(item);
            fakturyEntities.SaveChanges();
        }
        public class TowarForComboBox
        {
            public int IdTowaru { get; set; }
            public string NazwaTowaru { get; set; }
        }

        public class MagazynForComboBox
        {
            public int IdMagazynu { get; set; }
            public string NazwaMagazynu { get; set; }
        }
        #endregion
    }
}

