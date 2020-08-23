using Cookbook.Command;
using Cookbook.Model;
using Cookbook.View;
using Cookbook.View.Admin;
using System;
using System.Windows;
using System.Windows.Input;

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

        #region Commands
        //removing recipe
        private ICommand deleteRecipe;
        public ICommand DeleteRecipe
        {
            get
            {
                if (deleteRecipe == null)
                {
                    deleteRecipe = new RelayCommand(param => DeleteClinicMaintenanceExecute(), param => CanDeleteClinicMaintenance());
                }
                return deleteRecipe;
            }
        }

        private bool CanDeleteClinicMaintenance()
        {
            if (RecipesData.Recipe == null)
                return false;
            return true;
        }

        private void DeleteClinicMaintenanceExecute()
        {
            try
            {
                if (RecipesData.Recipe != null)
                {
                    ShouldDeleteView deleteOrder = new ShouldDeleteView();
                    deleteOrder.lblText.Content = "Are you sure you want to delete this recipe?";
                    deleteOrder.ShowDialog();
                    if ((deleteOrder.DataContext as ShouldDeleteViewModel).ShouldDelete == true)
                    {
                        bool isRemovedRecipe = db.TryRemoveRecipe(RecipesData.Recipe.RecipeID);
                        if (isRemovedRecipe == true)
                        {
                            MessageBox.Show("You have successfully deleted the recipe.");
                            RecipesData.Recipes = db.LoadRecipes();
                        }
                        else
                            MessageBox.Show("Something went wrong. The recipe is not deleted.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
    }
}
