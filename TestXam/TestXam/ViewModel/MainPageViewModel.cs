using Acr.UserDialogs;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestXam.ViewModel
{
    public class MainPageViewModel: ViewModelBase
    {

        #region--prop
        #endregion

        #region--ctor

        public MainPageViewModel(INavigationService navigationService, IUserDialogs userDialogs) :base(navigationService,userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            Title = "Main Page";
        }
        #endregion
    }
}
