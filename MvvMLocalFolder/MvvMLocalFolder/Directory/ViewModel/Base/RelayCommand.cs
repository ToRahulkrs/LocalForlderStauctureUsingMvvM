

using System;
using System.Windows.Input;

namespace MvvMLocalFolder
{
    public class RelayCommand : ICommand
    {
        private Action mAction;

        public RelayCommand(Action action)
        {
            mAction = action;
        }

        public event EventHandler CanExecuteChanged= (Sender, e)=> { };

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
