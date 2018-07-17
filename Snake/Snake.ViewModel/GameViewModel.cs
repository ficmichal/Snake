using GalaSoft.MvvmLight;
using Snake.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        #region Fields

        private IFrameNavigationService _navigationService;

        #endregion

        #region Constructor

        public GameViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #endregion
    }
}
