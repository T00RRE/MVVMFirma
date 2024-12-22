using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class jedenViewModel<T>:WorkspaceViewModel, IDataErrorInfo 
    { 
        #region DB
        protected Faktury2024Entities FakturyEntities;
        #endregion
        #region Item
        protected T item;
        #endregion
        #region Command 
        //to jest komenda, która zostanie podpieta pod przycisk zapisz i zamknij i ona wywola funkcje SaveAndClose
        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                return _SaveCommand;

            }


        }
        protected bool IsValid()
        {
            foreach(System.Reflection.PropertyInfo item in GetType().GetProperties()) {
            if(!string.IsNullOrEmpty(ValidateProperty(item.Name))) {
                    return false;
                }
            
            }
            return true;
        }
        private void ValidateAndSave()
        {
            try
            {
                if (IsValid())
                {
                    Save();
                }
                else
                {
                    MessageBox.Show("Nie mozna zapisac", "OK");
                }
            }
            catch
            {
                MessageBox.Show("Wystopił Błąd", "Ok");
            }

        }
        public string Error => string.Empty;
        // ta metoda (property) implementuj w każej klasie gdzie bedziemy walidować
        public string this[string columnName]{
        get
            {
                return ValidateProperty(columnName);
            }
        }

        protected virtual string ValidateProperty(string propertyname)
        {
            return string.Empty;    
        }

        #endregion
        #region Konstruktor
        public jedenViewModel(String displayName)
        {
            base.DisplayName = displayName;
            FakturyEntities = new Faktury2024Entities();
            
        }
        #endregion
        #region Helpers
        public abstract void Save();
        public  void SaveAndClose()
        {
            ValidateAndSave();
            base.OnRequestClose(); //zamkniecie zakladki
        }
        
        #endregion
    }
}
