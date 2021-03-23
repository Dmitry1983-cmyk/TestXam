using Acr.UserDialogs;
using Plugin.Media;
using Plugin.Settings;
using Prism;
using Prism.Ioc;
using System;
using TestXam.View;
using TestXam.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXam
{
    public partial class App
    {
        public App() : this(null) { }
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SignInPage, SignInPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            containerRegistry.RegisterInstance(UserDialogs.Instance);
            containerRegistry.RegisterInstance(CrossMedia.Current);
            containerRegistry.RegisterInstance(CrossSettings.Current);

        }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("NavigationPage/SignInPage");
        }
    }
}
