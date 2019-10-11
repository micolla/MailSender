using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicketsSelling.Entities;
using TicketsSelling.MVVM;

namespace TicketsSelling.ViewModel.BaseEditorVM
{
    public class BaseEditorVM<T> : MVVM.BaseEditorVM where T : BaseEntity
    {
        string _WindowTitle = "Добавление сеанса";
        public string WindowTitle
        {
            get => _WindowTitle;
            set => Set(ref _WindowTitle, value);
        }
        public event EventHandler Save;
        public event EventHandler Canceled;
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        protected virtual void OnSaveCommand(object obj) => Save?.Invoke(this, EventArgs.Empty);
        protected virtual void OnCancelCommand(object obj) => Canceled?.Invoke(this, EventArgs.Empty);
        protected T _Entity;
        public T Entity
        {
            get => _Entity;
            set => Set(ref _Entity, value);
        }
        public BaseEditorVM(T entity)
        {
            Entity = entity;
            SaveCommand = new LambdaCommand(OnSaveCommand);
            CancelCommand = new LambdaCommand(OnCancelCommand);
        }
        protected override bool Set<F>(ref F field, F value, [CallerMemberName] string PropertyName = null)
        {
            return base.Set(ref field, value, PropertyName);
        }
    }
}
