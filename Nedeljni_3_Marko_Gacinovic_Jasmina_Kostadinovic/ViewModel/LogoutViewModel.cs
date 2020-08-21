using Cookbook.Command;
using Cookbook.ViewModel;
using System.Windows.Input;

namespace Cookbook.ViewModel
{
    class LogoutViewModel : ViewModelBase
    {
        //logging out

        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => ExitExecute(), param => CanExitExecute());
                }
                return logout;
            }
        }

        protected virtual bool CanExitExecute()
        {
            return true;
        }

        protected virtual void ExitExecute()
        {
        }
    }
}
