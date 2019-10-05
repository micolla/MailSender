using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MailSender.Lib.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MailSender.ViewModel.BaseEditorVM
{
    public class BaseEditorVM<T> : ViewModelBase where T : BaseEntity
    {
        public event EventHandler Save;
        public event EventHandler Canceled;
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        protected virtual void OnSaveCommand() => Save?.Invoke(this, EventArgs.Empty);
        protected virtual void OnCancelCommand() => Canceled?.Invoke(this, EventArgs.Empty);
        protected T _Entity;
        public T Entity
        {
            get => _Entity;
            set => Set(ref _Entity, value);
        }
        public BaseEditorVM(T entity)
        {
            Entity = entity;
            SaveCommand = new RelayCommand(OnSaveCommand);
            CancelCommand = new RelayCommand(OnCancelCommand);
        }
    }
}
