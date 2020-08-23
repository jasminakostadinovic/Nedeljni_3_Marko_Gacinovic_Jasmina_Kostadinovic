using Cookbook.Command;
using Cookbook.Model;
using Cookbook.View.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cookbook.ViewModel.User
{
    class AddNewRecipeModel : ViewModelBase
    {
        AddNewRecipe addRecipe;

        private tblRecipe recipe;
        public tblRecipe Recipe
        {
            get { return recipe; }
            set { recipe = value; OnPropertyChanged("Recipe"); }
        }

        private tblUserData user;
        public tblUserData User
        {
            get { return user; }
            set { user = value; OnPropertyChanged("User"); }
        }        

        private bool isUpdateRecipe;
        public bool IsUpdateRecipe
        {
            get { return isUpdateRecipe; }
            set { isUpdateRecipe = value; }
        }


        public AddNewRecipeModel(AddNewRecipe addRecipeOpen, tblUserData userToPass)
        {
            addRecipe = addRecipeOpen;
            user = userToPass;
            recipe = new tblRecipe();            
        }

        // commands
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
            return true;
        }

        private void SaveExecute()
        {
            try
            {
                using (CookbookEntities context = new CookbookEntities())
                {
                    tblRecipe newRecipe = new tblRecipe();

                    newRecipe.Name = recipe.Name;

                    string type = recipe.Type.ToUpper();

                    // gender validation
                    if ((type == "A" || type == "M" || type == "D"))
                    {
                        newRecipe.Type = recipe.Type;
                    }
                    else
                    {
                        MessageBox.Show("Wrong Type input, please enter A, M or D.\n(Appetizer/Main course/Dessert)");
                    }

                    newRecipe.Description = recipe.Description;
                    newRecipe.DateCreated = recipe.DateCreated;
                    newRecipe.PersonsCount = recipe.PersonsCount;

                    newRecipe.RecipeID = recipe.RecipeID;
                    newRecipe.UserDataID = user.UserDataID;

                    context.tblRecipes.Add(newRecipe);
                    context.SaveChanges();

                    IsUpdateRecipe = true;

                    MessageBox.Show("The recipe created successfully.");
                }
                addRecipe.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong inputs, please check your inputs or try again.");
            }
        }

        // command for closing the window
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        /// <summary>
        /// method for closing the window
        /// </summary>
        private void CloseExecute()
        {
            try
            {
                addRecipe.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        private bool CanCloseExecute()
        {
            return true;
        }        
    }
}
