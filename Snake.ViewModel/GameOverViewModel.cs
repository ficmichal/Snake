using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        private RelayCommand _menuCommand;
        #endregion

        #region Properties
        public string TextLabel
        {
            get
            {
                return _textLabel;
            }
        }

        public RelayCommand GameOverCommand
        {
            get
            {
                return _menuCommand
                    ?? (_menuCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Menu");
                    }));
            }
        }
        #endregion

        #region Properties
        public GameOverViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion
    }
}