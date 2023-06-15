﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BillingSystemInWPF.ViewModels
{
    public class RelayClassViewModel : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<object> action;

        public RelayClassViewModel(Action<object> action) 
        {
            this.action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
