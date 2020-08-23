using Cookbook.Model;
using Cookbook.View.User;

namespace Cookbook.ViewModel.User
{
    class UserViewModel : LogoutViewModel
    {
        #region Fields
        private readonly UserView userView;
        private readonly DataAccess db = new DataAccess();
        private RecipesData recipesData;
        private tblUserData user;
        #endregion
        #region Constructors
        public UserViewModel(UserView userView, tblUserData user)
        {
            this.userView = userView;
            RecipesData = new RecipesData();
            this.user = user;
        }
        #endregion
        #region Properties
        public RecipesData RecipesData
        {
            get
            {
                return recipesData;
            }
            set
            {
                recipesData = value;
                OnPropertyChanged(nameof(RecipesData));
            }
        }
        #endregion
        #region Methods
        protected override void ExitExecute()
        {
            MainWindow loginWindow = new MainWindow();
            userView.Close();
            loginWindow.Show();
        }
        #endregion
    }
}
