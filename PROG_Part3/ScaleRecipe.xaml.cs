﻿using System;
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
using System.Windows.Shapes;

namespace PROG_Part3
{
    public partial class ScaleRecipe : UserControl
    {
        public ScaleRecipe()
        {
            InitializeComponent();
        }

        private void RecipeNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection changed event of the RecipeNameComboBox here
            // Add your code to handle the selected item or perform any other actions
        }

        private void ScaleFactorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection changed event of the ScaleFactorComboBox here
            // Add your code to handle the selected item or perform any other actions
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection changed event of the ComboBox here
            // Add your code to handle the selected item or perform any other actions
        }

        private void ComboBox_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection changed event of the ComboBox here
            // Add your code to handle the selected item or perform any other actions
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection changed event of the DataGrid here
            // Add your code to handle the selected item or perform any other actions
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            // Retrieve the stored window state
            WindowState windowState = Window.GetWindow(this)?.WindowState ?? WindowState.Normal;

            // Pass the window state to the MainWindow
            mainWindow.WindowState = windowState;

            Application.Current.MainWindow = mainWindow;
            Window.GetWindow(this)?.Close();
            mainWindow.Show();
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection changed event of the ComboBox here
            // Add your code to handle the selected item or perform any other actions
        }

        private void StepsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
