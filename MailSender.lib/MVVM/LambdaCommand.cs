﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MailSender.lib.MVVM
{
    public class LambdaCommand : ICommand
    {
        private Action<object> _CommandAction;
        private Func<object, bool> _CanExecute;

        public LambdaCommand(Action<object> CommandAction,
            Func<object, bool> CanExecute = null)
        {
            _CommandAction = CommandAction;
            _CanExecute = CanExecute;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => _CommandAction(parameter);
    }
}