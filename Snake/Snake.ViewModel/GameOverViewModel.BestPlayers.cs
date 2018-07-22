using GalaSoft.MvvmLight;
using Snake.Players;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.ViewModel
{
    public partial class GameOverViewModel : ViewModelBase
    {
		public class BestPlayers
        {
            public string Position { get; set; }

			public Player Player { get; set; }
        }
    }
}
