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
        private RelayCommand _toGameCommand;
        #endregion

        #region Properties
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