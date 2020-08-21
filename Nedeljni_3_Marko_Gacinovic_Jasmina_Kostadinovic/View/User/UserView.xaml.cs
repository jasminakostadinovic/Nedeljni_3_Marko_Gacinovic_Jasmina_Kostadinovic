using Cookbook.ViewModel.User;
using System.Windows;
using System.Windows.Controls;

namespace Cookbook.View.User
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        public UserView()
        {
            InitializeComponent();
            this.DataContext = new UserViewModel(this);
        }
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //hiding id columns
            if (e.Column.Header.ToString() == "RecipeID"
                 || e.Column.Header.ToString() == "UserDataID"
                 || e.Column.Header.ToString() == "DateCreated"
                 || e.Column.Header.ToString() == "tblUserData"
                 || e.Column.Header.ToString() == "tblIngredients"
                 || e.Column.Header.ToString() == "tblShoppingLists")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }
    }
}
