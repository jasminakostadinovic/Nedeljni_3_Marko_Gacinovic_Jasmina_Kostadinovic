using Cookbook.ViewModel;
using System.Windows;

namespace Cookbook.View
{
    /// <summary>
    /// Interaction logic for ShouldDeleteView.xaml
    /// </summary>
    public partial class ShouldDeleteView : Window
    {
        public ShouldDeleteView()
        {
            InitializeComponent();
            DataContext = new ShouldDeleteViewModel(this);
        }
        public void Show(string message)
        {
            lblText.Content = message;
            this.Show();
        }
    }
}
