﻿using Snake.ViewModel;
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
using System.Windows.Shapes;

namespace Snake.Snake.View
{
    /// <summary>
    /// Logika interakcji dla klasy GameOver.xaml
    /// </summary>
    public partial class GameOver : Page
    {
        public GameOver()
        {
            InitializeComponent();
            Loaded += GameOverViewReset;
        }

        private void GameOverViewReset(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.ResetGameOverViewModel();
        }
    }
}
