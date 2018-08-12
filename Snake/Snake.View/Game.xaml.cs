using Snake.ViewModel;
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
    /// Logika interakcji dla klasy Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        public Game()
        {
            InitializeComponent();
            Unloaded += GameViewReset;
        }

        /// <summary>
        /// Restart GameView, when game is over. (In case of play again).
        /// </summary>
        private void GameViewReset(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.ResetGameViewModel();
        }
    }
}
