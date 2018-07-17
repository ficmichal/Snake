using GalaSoft.MvvmLight;
using Snake.Snake.Model;
using Snake.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Snake.Snake.Model.Grid;

namespace Snake.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        #region Fields

        private IFrameNavigationService _navigationService;

        #endregion

        #region Properties

        public ObservableCollection<CellItem> CellItems { get; set; }
        public Grid GridViewModel { get; set; }

        #endregion

        #region Constructor and his methods

        public GameViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            LoadBoard();
        }

        private void LoadBoard()
        {
            GridViewModel = new Grid();
            CellItems = new ObservableCollection<CellItem>();

            int _boardSize = 20;
            for (int i = 0; i < _boardSize; i++)
            {
                for (int j = 0; j < _boardSize; j++)
                {
                    Cell cell = GridViewModel.Board[i, j];
                    CellItem cellItem = new CellItem(i*15, j*15, 15, 15, RenderFill(cell));
                    CellItems.Add(cellItem);
                }
            }
        }

        private string RenderFill(Cell cell)
        {
            string result = String.Empty;

            switch (cell)
            {
                case Cell.EMPTY:
                    result = "White";
                    break;
                case Cell.FOOD:
                    result = "Red";
                    break;
                case Cell.SNAKE:
                    result = "Green";
                    break;
                default:
                    result = "White";
                    break;
            }

            return result;
        }
        #endregion
    }
}
