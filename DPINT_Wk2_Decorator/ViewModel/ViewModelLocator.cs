/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:DPINT_Wk2_Decorator"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;
using System;
using GalaSoft.MvvmLight.Views;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Messaging;
using DPINT_Wk2_Decorator.View;
using System.Threading;

namespace DPINT_Wk2_Decorator.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private FighterViewModel _firstFighterViewModel;
        private FighterViewModel _secondFighterViewModel;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        }
                
        public FighterViewModel Fighter
        {
            get
            {
                if(_firstFighterViewModel == null)
                {
                    _firstFighterViewModel = new FighterViewModel();
                    _secondFighterViewModel = new FighterViewModel();

                    _firstFighterViewModel.EnemyFighterViewModel = _secondFighterViewModel;
                    _secondFighterViewModel.EnemyFighterViewModel = _firstFighterViewModel;

                    if (!ViewModelBase.IsInDesignModeStatic)
                    {
                        new FighterView() { Top = 100, Left = 200 }.Show();
                    }

                    return _firstFighterViewModel;
                } else
                {
                    return _secondFighterViewModel;
                }
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}