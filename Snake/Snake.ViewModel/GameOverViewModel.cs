using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Snake.Snake.View;
using Snake.ViewModel.Helpers;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace Snake.ViewModel
{
    /// <summary>
    /// The ViewModel responsible for supplying data and behavior for the game-over dialog.
    /// </summary>
    public class GameOverViewModel : ViewModelBase
    {
        #region Fields
        private IFrameNavigationService _navigationService;
        private string _textLabel = "GAME OVER";
        private string _playAgainButton = "PLAY AGAIN?";
        private RelayCommand _toMenuCommand;
        private RelayCommand _toGameCommand;
        #endregion

        #region Properties
        public string TextLabel
        {
            get
            {
                return _textLabel;
            }
        }

        public RelayCommand ToMenuCommand
        {
            get
            {
                return _toMenuCommand
                    ?? (_toMenuCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Menu");
                    }));
            }
        }

        public RelayCommand ToGameCommand
        {
            get
            {
                return _toGameCommand
                    ?? (_toGameCommand = new RelayCommand(
                    () =>
                    {
                        //ViewModelLocator.ResetGameViewModel()
                        _navigationService.NavigateTo("Game");
                    }));
            }
        }
        #endregion



        #region Constructor
        public GameOverViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion
    }
}