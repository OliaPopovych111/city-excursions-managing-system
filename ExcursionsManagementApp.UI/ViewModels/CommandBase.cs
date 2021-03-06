﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ExcursionsManagementApp.UI.ViewModels
{
    public class CommandBase<T> : INotifyPropertyChanged
    {
        private ICommand getCommand;
        private ICommand saveCommand;
        private ICommand removeCommand;
        private bool canExecute;

        public CommandBase()
        {
             canExecute = true;
        }

        #region "INotifyPropertyChanged members"

        public event PropertyChangedEventHandler PropertyChanged;
        //This routine is called each time a property value has been set. 
        //This will //cause an event to notify WPF via data-binding that a change has occurred. 
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        private ObservableCollection<T> collection;
        public ObservableCollection<T> Collection
        {
            get
            {
                if (collection == null)
                {
                    collection = new ObservableCollection<T>();
                }
                return collection;
            }
            set { collection = value; OnPropertyChanged("Collection"); }
        }

        public ICommand GetCommand
        {
            get
            {
                return getCommand ?? (getCommand = new CommandHandler(() => Get(), canExecute));
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new CommandHandler(() => Save(), canExecute));
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return removeCommand ?? (removeCommand = new CommandHandler(() => Delete(), canExecute));
            }
        }

        protected virtual void Get()
        {
            throw new NotImplementedException();
        }
        protected virtual void Save()
        {
            throw new NotImplementedException();
        }
        protected virtual void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
