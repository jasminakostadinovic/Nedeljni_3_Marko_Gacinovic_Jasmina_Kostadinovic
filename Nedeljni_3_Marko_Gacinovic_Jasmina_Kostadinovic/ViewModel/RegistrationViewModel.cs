using Cookbook.Model;
using Cookbook.View;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Cookbook.Command;
using Cookbook.Validations;
using System.Windows;
using Cookbook.View.User;
using Cookbook.ViewModel.User;

namespace Cookbook.ViewModel
{
    class RegistrationViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Fields
        private readonly RegistrationView registrationView;
        private tblUserData user;
        private string surname;
        private string givenName;
        private string username;
        private string password;
        private readonly DataAccess db = new DataAccess();
        #endregion
        #region Properties
     
        public bool IsAddedNewUser { get; internal set; }
        public bool CanSave { get; set; }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password == value) return;
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (username == value) return;
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (surname == value) return;
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string GivenName
        {
            get
            {
                return givenName;
            }
            set
            {
                if (givenName == value) return;
                givenName = value;
                OnPropertyChanged(nameof(GivenName));
            }
        }
        #endregion
        #region Constructors
        public RegistrationViewModel(RegistrationView registrationView)
        {
            this.registrationView = registrationView;
            Username = string.Empty;
            Password = string.Empty;
            GivenName = string.Empty;
            Surname = string.Empty;
            user = new tblUserData();
            CanSave = true;
        }

        #endregion

        #region IDataErrorInfoImplementation
        //validations

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string name]
        {
            get
            {
                CanSave = true;
                string validationMessage = string.Empty;
                if (name == nameof(Username))
                {
                    if (!db.IsUniqueUsername(Username))
                    {
                        validationMessage = "Username number must be unique!";
                        CanSave = false;
                    }
                }
                else if (name == nameof(Password))
                {
                    if (Password.Length < 5)
                    {
                        validationMessage = "Password must contain at least 5 characters!";
                        CanSave = false;
                    }
                }
                if (string.IsNullOrEmpty(validationMessage))
                    CanSave = true;

                return validationMessage;
            }
        }
        #endregion

        #region Commands
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        private bool CanSaveExecute()
        {
            if (
                string.IsNullOrWhiteSpace(Surname)
                || string.IsNullOrWhiteSpace(Password)
                || string.IsNullOrWhiteSpace(GivenName)
                || string.IsNullOrWhiteSpace(Username)
                || CanSave == false)
                return false;
            return true;
        }
        private void SaveExecute()
        {
            try
            {
                user.GivenName = GivenName;
                user.Surname = Surname;
                user.Password = SecurePasswordHasher.Hash(Password);
                user.Username = Username;
                //adding new institution to database 
                IsAddedNewUser = db.TryAddNewUserData(user);
                if (!IsAddedNewUser)
                {
                    MessageBox.Show("Something went wrong. The new useris not created.");
                    MainWindow login = new MainWindow();
                    login.Show();
                    registrationView.Close();
                    return;
                }                              
                else
                {
                    MessageBox.Show("The new user is sucessfully created.");
                    UserView userView = new UserView();
                    registrationView.Close();
                    userView.Show();
                    return;
                }      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Escaping action
        private ICommand exit;
        public ICommand Exit
        {
            get
            {
                if (exit == null)
                {
                    exit = new RelayCommand(param => ExitExecute(), param => CanExitExecute());
                }
                return exit;
            }
        }

        private bool CanExitExecute()
        {
            return true;
        }

        private void ExitExecute()
        {
            MainWindow login = new MainWindow();
            registrationView.Close();
            login.Show();
        }
        #endregion
    }
}
