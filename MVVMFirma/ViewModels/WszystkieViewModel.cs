﻿using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class WszystkieViewModel<T>:WorkspaceViewModel
    {
        #region DB
        protected readonly Faktury2024Entities fakturyEntities; //to jest pole które reprezentuje bazy danych
        #endregion
        #region Command
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
        private BaseCommand _AddCommand; //to jest komenda wywołująca funkcje Add wywołującą okno do dodawania i zostanie podpięta pod przycisk Dodaj
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                    _AddCommand = new BaseCommand(() => add());
                return _AddCommand;
            }
        }
        #endregion
        #region DodajCommand
        //private ICommand _dodajCommand;
        //public ICommand DodajCommand
        //{
        //    get
        //    {
        //        if (_dodajCommand == null)
        //            _dodajCommand = new BaseCommand(() => ShowAddWindow());
        //        return _dodajCommand;
        //    }
        //}


        //public abstract void ShowAddWindow();
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
        #region DeleteCommand
        private BaseCommand _UsunCommand;
        public ICommand UsunCommand
        {
            get
            {
                if (_UsunCommand == null)
                    _UsunCommand = new BaseCommand(() => UsunRecord());
                return _UsunCommand;
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
        #region Sort And Filtr
        //sort
        //wynik wyboru po czym sortować zostanie zapisany w SortField
        public string SortField { get; set; }

        public  List<string> SortComboboxItems
        {
            get
            {
                return GetCombobocSortList();
            }
        }
        public abstract List<string> GetCombobocSortList();
        private BaseCommand _SortCommand; //to jest komenda, która będzie wywoływałą po nacisnieniu na przycisk sortuj
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                    _SortCommand = new BaseCommand(() => Sort());
                return _SortCommand;
            }
        }
        public abstract void Sort();
        //filtr////////////////////////////
        public string FindField { get; set; }

        public List<string> FindComboboxItems
        {
            get
            {
                return GetCombobocFindList();
            }
        }
        public abstract List<string> GetCombobocFindList();
        public string FindTextBox { get; set; }
        private BaseCommand _FindCommand; //to jest komenda, która będzie wywoływałą po nacisnieniu na przycisk szukaj
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                    _FindCommand = new BaseCommand(() => Find());
                return _FindCommand;
            }
        }
        public abstract void Find();


        #endregion
        #region Properties
        private int _WybraneId;
        public int WybraneId
        {
            get
            {
                return _WybraneId;
            }
            set
            {
                _WybraneId = value;
                OnPropertyChanged(() => WybraneId);
            }
        }
        #endregion
        #region Helpers
        // metoda load pobiera wszystkie towary z bazy danych;
        public abstract void Load(); 
        public void add()
        {
            //Messenger jest z biblioteki MVVMlight 
            //dzięki messengerowi wysyłamy do innych obiektów komunikat DisplayName Add gdzie displayname jest nazwą widoku
            //ten odbierze MainWindowViewModel które odpowiada za otwieranie zakładek
            Messenger.Default.Send(DisplayName + "Add");
        }
        public void UsunRecord()
        {
            if (WybraneId == 0) return;

            var result = MessageBox.Show(
                $"Czy na pewno chcesz usunąć wybrany rekord? Ta operacja jest nieodwracalna.",
                "Potwierdzenie usunięcia",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Delete();
                    Load();

                    MessageBox.Show(
                        "Rekord został usunięty pomyślnie.",
                        "Sukces",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Wystąpił błąd podczas usuwania: {ex.Message}",
                        "Błąd",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }

        protected abstract void Delete();
        #endregion
    }
}
