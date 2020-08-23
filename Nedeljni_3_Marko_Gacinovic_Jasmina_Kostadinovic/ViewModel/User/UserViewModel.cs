using Cookbook.Command;
using Cookbook.Model;
using Cookbook.View.User;
using System;
using System.Collections.Generic;
using System.Windows.Input;

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

        #region Commands
        private ICommand addRecipe;
        public ICommand AddRecipe
        {
            get
            {
                if (addRecipe == null)
                {
                    addRecipe = new RelayCommand(param => AddRecipeExecute(), param => CanAddRecipeExecute());
                }
                return addRecipe;
            }
        }

        private bool CanAddRecipeExecute()
        {
            return true;
        }

        private void AddRecipeExecute()
        {
            try
            {
                AddNewRecipe recipe = new AddNewRecipe(user);
                recipe.ShowDialog();

                // updating the lists view
                if ((recipe.DataContext as AddNewRecipeModel).IsUpdateRecipe == true)
                {
                    RecipesData.Recipes = db.LoadRecipes();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());                
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
