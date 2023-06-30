using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace PROG_Part3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddRecipeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Redirect to the addRecipe.xaml page
            addRecipe addRecipeWindow = new addRecipe();
            Content = addRecipeWindow;
        }

    }
}
