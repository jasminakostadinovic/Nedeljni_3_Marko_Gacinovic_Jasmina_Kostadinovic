using Cookbook.Model;
using Cookbook.View.Admin;
using Cookbook.ViewModel;

namespace Cookbook.ViewModel.Admin
{
    class AdminViewModel : LogoutViewModel
    {
        #region Fields
        private readonly AdminView adminView;
        private readonly DataAccess db = new DataAccess();
        private RecipesData recipesData;
        #endregion
        #region Constructors
        public AdminViewModel(AdminView adminView)
        {
            this.adminView = adminView;
            RecipesData = new RecipesData();
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
            adminView.Close();
            loginWindow.Show();
        }
        #endregion
    }
}
