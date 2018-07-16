using GalaSoft.MvvmLight.Views;

namespace Snake.ViewModel.Helpers
{
    public interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }
    }
}
