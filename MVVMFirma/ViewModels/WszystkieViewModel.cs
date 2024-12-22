using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class WszystkieViewModel<T>:WorkspaceViewModel
    {
        #region DB
        protected readonly Faktury2024Entities fakturyEntities; //to jest pole które reprezentuje bazy danych
        #endregion
        #region LoadCommand
        private BaseCommand _LoadCommand; //to jest komenda, która będzie wywoływałą funkcje Load pobierającą z bazy danych towary
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => Load());
                return _LoadCommand;
            }
        }

        #endregion
        #region DodajCommand
        private ICommand _dodajCommand;
        public ICommand DodajCommand
        {
            get
            {
                if (_dodajCommand == null)
                    _dodajCommand = new BaseCommand(() => ShowAddWindow());
                return _dodajCommand;
            }
        }

        
        public abstract void ShowAddWindow();
        #endregion
        #region OdswiezCommand
        private BaseCommand _OdswiezCommand;
        public ICommand OdswiezCommand
        {
            get
            {
                if (_OdswiezCommand == null)
                    _OdswiezCommand = new BaseCommand(() => Load());
                return _OdswiezCommand;
            }
        }
        #endregion
        #region List
        private ObservableCollection<T> _List; //tu będą przechowywane towary z bazy danych
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                {
                    _List = new ObservableCollection<T>();
                    Load();
                }
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);//to jest zlecenie odswiezenia listy na interfejsie
            }
        }
        #endregion
        #region Constructor
        public WszystkieViewModel(String displayname)
        {
            
            fakturyEntities = new Faktury2024Entities();
            base.DisplayName = displayname;


        }
        #endregion
        #region Helpers
        // metoda load pobiera wszystkie towary z bazy danych;
        public abstract void Load(); 
        #endregion
    }
}
