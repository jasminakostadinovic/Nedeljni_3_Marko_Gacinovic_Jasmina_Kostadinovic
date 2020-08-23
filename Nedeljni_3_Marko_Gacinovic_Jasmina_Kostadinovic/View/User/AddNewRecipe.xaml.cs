using Cookbook.Model;
using Cookbook.ViewModel.User;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Cookbook.View.User
{
    /// <summary>
    /// Interaction logic for AddNewRecipe.xaml
    /// </summary>
    public partial class AddNewRecipe : Window
    {
        public AddNewRecipe(tblUserData user)
        {
            InitializeComponent();
            this.DataContext = new AddNewRecipeModel(this, user);
        }

        private void NumbersTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
