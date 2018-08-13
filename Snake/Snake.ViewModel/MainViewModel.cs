using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Snake.ViewModel.Helpers;

namespace Snake.ViewModel
{
    /// <summary>
    /// This is the top-level view model class.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private RelayCommand _loadedCommand;

        public RelayCommand LoadedCommand
        {
            get
            {
                return _loadedCommand
                    ?? (_loadedCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Menu");
                    }));
            }
        }

        public MainViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}