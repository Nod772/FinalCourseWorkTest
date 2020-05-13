using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvmTest.ViewModel.Comands
{
    public class RegisterTeacherCommand : ICommand
    {
        TeacherVM VM { get; set; }
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

        public RegisterTeacherCommand(TeacherVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return parameter != null;
        }

        public void Execute(object parameter)
        {
            VM.Registers(parameter as string);

        }
    }
}
