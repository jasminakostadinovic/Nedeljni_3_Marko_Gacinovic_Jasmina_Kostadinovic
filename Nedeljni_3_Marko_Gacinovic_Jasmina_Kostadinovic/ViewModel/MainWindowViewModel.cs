using Cookbook.Command;
using Cookbook.View.Admin;
using Cookbook.Model;
using Cookbook.View;
using System.Windows.Controls;
using System.Windows.Input;
using Cookbook.ViewModel.User;
using Cookbook.View.User;

namespace Cookbook.ViewModel
{
	class MainWindowViewModel : ViewModelBase
    {
		#region Fields
		private string userName;
		readonly MainWindow loginView;
		private readonly DataAccess db = new DataAccess();
		#endregion

		#region Constructor
		internal MainWindowViewModel(MainWindow view)
		{
			this.loginView = view;
		}
		#endregion

		#region Properties
		public string UserName
		{
			get
			{
				return userName;
			}
			set
			{
				userName = value;
				OnPropertyChanged(nameof(UserName));
			}
		}
		#endregion
		//login
		private ICommand submitCommand;
		public ICommand SubmitCommand
		{
			get
			{
				if (submitCommand == null)
				{
					submitCommand = new RelayCommand(Submit);
					return submitCommand;
				}
				return submitCommand;
			}
		}

		void Submit(object obj)
		{
			string password = (obj as PasswordBox).Password;

			if (UserName == Constants.adminUsername && password == Constants.adminPassword)
			{
				AdminView adminView = new AdminView();
				loginView.Close();
				adminView.Show();
				return;
			}
			else if (db.IsCorrectUser(userName, password))
			{
				var user= db.LoadUserByUsername(userName);
				if (user != null)
				{
					UserView userView = new UserView(user);
					loginView.Close();
					userView.Show();
					return;
				}
			}
			else
			{
				WarningView warning = new WarningView(loginView);
				warning.Show("User name or password are not correct!");
				UserName = null;
				(obj as PasswordBox).Password = null;
				return;
			}
		}

		//registrate
		private ICommand registrateCommand;
		public ICommand RegistrateCommand
		{
			get
			{
				if (registrateCommand == null)
				{
					registrateCommand = new RelayCommand(Register);
					return registrateCommand;
				}
				return registrateCommand;
			}
		}

		private void Register(object obj)
		{
			RegistrationView registrateView = new RegistrationView();
			loginView.Close();
			registrateView.Show();
			return;
		}
	}
}
