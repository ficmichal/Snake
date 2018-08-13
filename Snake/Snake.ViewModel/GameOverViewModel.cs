using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Snake.Players;
using Snake.Players.Repositories;
using Snake.Snake.View;
using Snake.ViewModel.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Snake.ViewModel
{
    /// <summary>
    /// The ViewModel responsible for supplying data and behavior for the game-over dialog.
    /// </summary>
    public partial class GameOverViewModel : ViewModelBase
    {
        #region Fields
        private IFrameNavigationService _navigationService;
        private RelayCommand _toGameCommand;
        private RelayCommand _toExitCommand;
        #endregion

        #region Properties

        public ObservableCollection<BestPlayers> TheBestPlayers { get; set; } =
            new ObservableCollection<BestPlayers>();
    
        public RelayCommand ToGameCommand
        {
            get
            {
                return _toGameCommand
                    ?? (_toGameCommand = new RelayCommand(
                    () =>
                    {
                        string actualNickname = (string)_navigationService.Parameter;
                        _navigationService.NavigateTo("Game", actualNickname);
                    }));
            }
        }

        public RelayCommand ToExitCommand
        {
            get
            {
                return _toExitCommand
                    ?? (_toExitCommand = new RelayCommand(
                    () =>
                    {
                        Application.Current.MainWindow.Close();
                    }));
            }
        }
        #endregion

        #region Constructor
        public GameOverViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            GetBestPlayers();
        }
        #endregion

        private void GetBestPlayers()
        {
            using (var repo = new PlayerRepository())
            {
                var bestPlayers = repo.GetAll().OrderByDescending(x => x.BestScore).Take(5).ToList();

                int i = 1;
                foreach(Player player in bestPlayers)
                {
                    BestPlayers oneOfBestPlayer = new BestPlayers
                    {
                        Position = String.Format(i.ToString() + "."),
                        Player = player
                    };
                    TheBestPlayers.Add(oneOfBestPlayer);
                    i++;
                }
            }
        }
    }
}