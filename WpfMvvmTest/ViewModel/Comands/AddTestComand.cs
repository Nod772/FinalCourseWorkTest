using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMvvmTest.Model;

namespace WpfMvvmTest.ViewModel.Comands
{
    public class AddTestComand : ICommand
    {
        AddTestVM VM { get; set; }
        public event EventHandler CanExecuteChanged
        {

            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;

            }
        }

        public AddTestComand(AddTestVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.AddTest();
        }
    }
}
