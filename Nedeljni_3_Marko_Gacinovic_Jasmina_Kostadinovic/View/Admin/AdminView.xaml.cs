using Cookbook.ViewModel.Admin;
using System.Windows;
using System.Windows.Controls;

namespace Cookbook.View.Admin
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        public AdminView()
        {
            InitializeComponent();
            this.DataContext = new AdminViewModel(this);
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
