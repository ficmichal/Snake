using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Snake.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        #region Fields

        private IFrameNavigationService _navigationService;
        private string _textLabel = "Please, enter&#10; your nickname:";
        private string _nickname = "Anonim";
        private RelayCommand _gameCommand;

        #endregion

        #region Properties

        public string TextLabel
        {
            get
            {
                return _textLabel;
            }
        }

        public string Nickname
        {
            get
            {
                return _nickname;
            }

            set
            {
                if (_nickname == value)
                {
                    return;
                }

                _nickname = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand GameCommand
        {
            get
            {
                return _gameCommand
                    ?? (_gameCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Game");
                    }));
            }
        }

        #endregion

        #region Constructor

        public MenuViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #endregion
    }
}