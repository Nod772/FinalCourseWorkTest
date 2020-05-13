using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvmTest.ViewModel.UserComands
{
    public class StartTestCommand : ICommand
    {
        UserVM VM { get; set; }
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

        public StartTestCommand(UserVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return parameter!=null;
        }

        public void Execute(object parameter)
        {
            VM.StartTesting();
        }
    }
}
