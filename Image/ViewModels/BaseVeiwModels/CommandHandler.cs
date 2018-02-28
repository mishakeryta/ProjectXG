

using System;
using System.Windows.Input;

namespace ProjectXG
{
    public class CommandHandler : ICommand
    {
        private Action mAction;
        private bool mCanExecute;
        public CommandHandler(Action action, bool canExecute)
        {
            mAction = action;
            mCanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return mCanExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
