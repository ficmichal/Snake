﻿using GalaSoft.MvvmLight.Ioc;
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
            SimpleIoc.Default.Register<GameViewModel>();
            SimpleIoc.Default.Register<GameOverViewModel>();
            SetupNavigation();
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure("Menu", new Uri("../Snake.View/Menu.xaml", UriKind.Relative));
            navigationService.Configure("Game", new Uri("../Snake.View/Game.xaml", UriKind.Relative));
            navigationService.Configure("GameOver", new Uri("../Snake.View/GameOver.xaml", UriKind.Relative));
            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public MenuViewModel MenuViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MenuViewModel>();
            }
        }

        public GameViewModel GameViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GameViewModel>();
            }
        }

        public GameOverViewModel GameOverViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GameOverViewModel>();
            }
        }

        public static void ResetGameViewModel()
        {
            SimpleIoc.Default.Unregister<GameViewModel>();
            SimpleIoc.Default.Register<GameViewModel>();
        }

        public static void ResetGameOverViewModel()
        {
            SimpleIoc.Default.Unregister<GameOverViewModel>();
            SimpleIoc.Default.Register<GameOverViewModel>();
        }
        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}