using Cookbook.Model;
using Cookbook.ViewModel;
using System.Collections.Generic;

namespace Cookbook.ViewModel
{
    class RecipesData : ViewModelBase
    {
        #region Fields
        private tblRecipe recipe;
        private List<tblRecipe> recipes;
        private readonly DataAccess db = new DataAccess();
        #endregion
        #region Constructors
        public RecipesData()
        {
            Recipes = db.LoadRecipes();
        }
#endregion
        #region Properties
        public tblRecipe Recipe
        {
            get
            {
                return recipe;
            }
            set
            {
                recipe = value;
                OnPropertyChanged(nameof(Recipe));
            }
        }
        public List<tblRecipe> Recipes
        {
            get
            {
                return recipes;
            }
            set
            {
                recipes = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }
        #endregion
    }
}
