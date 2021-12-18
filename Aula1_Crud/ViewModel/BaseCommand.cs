﻿using Aula1_Crud.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aula1_Crud
{
    // classe base dos comandos - implementando a interface ICommand
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) => true;
        public abstract void Execute(object parameter);

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
               

    }
      


}


