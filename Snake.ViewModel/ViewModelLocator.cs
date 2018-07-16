/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:Chargily.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using Snake.ViewModel.Helpers;
using CommonServiceLocator;

namespace Snake.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MenuViewModel>();
            SimpleIoc.Default.Register<GameOverViewModel>();
            SetupNavigation();
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure("Menu", new Uri("../View/Menu.xaml", UriKind.Relative));
            navigationService.Configure("GameOver", new Uri("../View/GameOver.xaml", UriKind.Relative));
            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public MenuViewModel Menu
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MenuViewModel>();
            }
        }

        public GameOverViewModel GameOverViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GameOverViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}