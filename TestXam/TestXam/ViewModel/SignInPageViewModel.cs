using Acr.UserDialogs;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestXam.View;
using Xamarin.Forms;

namespace TestXam.ViewModel
{
    public class SignInPageViewModel:ViewModelBase
    {
        private string _Placelogin;
        private string _Placepassword;
        private string _logIn;
        private string _signUp;

        private string _login;
        private string _password;

        #region--prop

        public string PlaceLogin
        {
            get { return _Placelogin; }
            set 
            {
                _Placelogin = value;
                SetProperty(ref _Placelogin,value);
            }
        }
        public string PlacePassword
        {
            get { return _Placepassword; }
            set
            {
                _Placepassword = value;
                SetProperty(ref _Placepassword,value);
            }
        }
        public string LogIn
        {
            get { return _logIn; }
            set
            {
                _logIn = value;
                SetProperty(ref _logIn, value);
            }
        }
        public string SignUp
        {
            get { return _signUp; }
            set
            {
                _signUp = value;
                SetProperty(ref _signUp,value);
            }
        }

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                SetProperty(ref _login,value);
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                SetProperty(ref _password,value);
            }
        }
        #endregion

        #region--ctor
        public SignInPageViewModel(INavigationService navigationService,IUserDialogs userDialogs) :base(navigationService,userDialogs)
        {
            Title = "Sign In Page";
            PlaceLogin = "Login";
            PlacePassword = "Password";
            LogIn = "LogIn";
            SignUp = "SignUp";

            _navigationService = navigationService;
            _userDialogs = userDialogs;
        }
        #endregion

        #region----method
        public ICommand SignUPCommand => new Command(ExecuteNavigateCommand_SignUP);
        async private void ExecuteNavigateCommand_SignUP()
        {
            await _navigationService.NavigateAsync(nameof(SignUpPage));
        }

        public ICommand SignInCommand => new Command(ExecuteNavigateCommand_SignIn);
        async private void ExecuteNavigateCommand_SignIn()
        {
            await _navigationService.NavigateAsync(nameof(MainPage));
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.TryGetValue("user", out string login))
            {
                Login = login;
                RaisePropertyChanged($"{nameof(Login)}");
            }
        }
        #endregion

    }
}
