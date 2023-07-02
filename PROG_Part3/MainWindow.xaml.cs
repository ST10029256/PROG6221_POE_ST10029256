using System;
using System.Windows;
using System.Windows.Controls;

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
            // Redirect to the AddRecipe.xaml page
            AddRecipe addRecipeWindow = new AddRecipe();
            Content = addRecipeWindow;

        }

        private void SearchRecipesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Redirect to the SearchForRecipe.xaml page
            SearchForRecipe searchRecipeWindow = new SearchForRecipe();
            Content = searchRecipeWindow;
        }

        private void ScaleRecipeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Redirect to the ScaleRecipe.xaml page
            ScaleRecipe scaleRecipeWindow = new ScaleRecipe();
            Content = scaleRecipeWindow;
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Redirect to the AddRecipe.xaml page
            AddRecipe addRecipeWindow = new AddRecipe();
            Content = addRecipeWindow;
        }

        private void SearchRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            // Redirect to the SearchForRecipe.xaml page
            SearchForRecipe searchRecipeWindow = new SearchForRecipe();
            Content = searchRecipeWindow;
        }

        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Redirect to the ScaleRecipe.xaml page
            ScaleRecipe scaleRecipeWindow = new ScaleRecipe();
            Content = scaleRecipeWindow;
        }

        public void ToggleFullscreen()
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
                ResizeMode = ResizeMode.NoResize;
            }
            else
            {
                WindowState = WindowState.Normal;
                WindowStyle = WindowStyle.SingleBorderWindow;
                ResizeMode = ResizeMode.CanResize;
            }
        }
    }
}
