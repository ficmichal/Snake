using GalaSoft.MvvmLight;
using Snake.Snake.Model;
using Snake.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using static Snake.Snake.Model.Grid;

namespace Snake.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        #region Fields

        private IFrameNavigationService _navigationService;
        private int _boardSize = 20;
        private int _sizeOfRect = 15;

        #endregion

        #region Properties

        public DispatcherTimer Timer { get; set; }

        public ObservableCollection<CellItem> CellItems { get; set; }

        public Grid GridModel { get; set; }

        #endregion

        #region Events

        private void TimerTick(object sender, EventArgs e)
        {
            GridModel.UpdateBoard();
            UpdateViewOfBoard();

            if(CheckGameOver())
            {
                Timer.Stop();
                 Application.Current.MainWindow.KeyDown -= new KeyEventHandler(GridModel.OnButtonKeyDown);
                _navigationService.NavigateTo("GameOver");
            }
        }
        #endregion

        #region Constructor and his methods

        public GameViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            LoadView();
            ConfigureTimer();
            Application.Current.MainWindow.KeyDown += new KeyEventHandler(GridModel.OnButtonKeyDown);
        }

        private void LoadView()
        {
            GridModel = new Grid();
            CellItems = new ObservableCollection<CellItem>();
            LoadBoard();
        }

        private void ConfigureTimer()
        {
            Timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(100)
            };
            Timer.Tick += new EventHandler(TimerTick);
            Timer.Start();
        }

        private void LoadBoard()
        {
            for (int i = 0; i < _boardSize; i++)
            {
                for (int j = 0; j < _boardSize; j++)
                {
                    Cell cell = GridModel.Board[i, j];
                    CellItem cellItem = new CellItem(_boardSize * i + j, i * _sizeOfRect,
                        j* _sizeOfRect, _sizeOfRect, _sizeOfRect, RenderFill(cell));
                    CellItems.Add(cellItem);
                }
            }
            GridModel.State = GameState.GAME;
        }

        private void UpdateViewOfBoard()
        {
            for (int i = 0; i < _boardSize; i++)
            {
                for (int j = 0; j < _boardSize; j++)
                {
                    Cell cell = GridModel.Board[i, j];
                    //Update Fill of Rectangle
                    CellItems.Where(x => x.Id == _boardSize * i + j).
                        FirstOrDefault().Fill = RenderFill(cell);
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

        private bool CheckGameOver()
        {
            if(GridModel.State == GameState.GAMEOVER)
               return true;

            return false;
        }
    }
}
