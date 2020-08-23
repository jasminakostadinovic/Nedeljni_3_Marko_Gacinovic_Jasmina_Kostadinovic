using Cookbook.Model;
using Cookbook.ViewModel.User;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Cookbook.View.User
{
    /// <summary>
    /// Interaction logic for UpdadeRecipeByUser.xaml
    /// </summary>
    public partial class UpdadeRecipeByUser : Window
    {
        public UpdadeRecipeByUser(tblRecipe recipe)
        {
            InitializeComponent();
            this.DataContext = new UpdadeRecipeByUserModel(this, recipe);
        }

        private void NumbersTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
