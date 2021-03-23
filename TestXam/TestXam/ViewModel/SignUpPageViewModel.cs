using Acr.UserDialogs;
using Plugin.Media.Abstractions;
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
    public class SignUpPageViewModel :ViewModelBase
    {
        private readonly IMedia _media;
        #region
        private string _ImagePath;
        private string _SignUP;
        private string _PlaceConfirm;
        private string _PlacePassword;
        private string _PlaceLogin;
        private string _PlaceLastName;
        private string _PlaceName;
        private string _PlacePhone;
        private string _Name;
        private string _LastName;
        private string _Login;
        private string _Password;
        private string _Confirm;
        private string _Phone;
        private ImageSource _PhotoImageSource;
        #endregion

        #region--prop
        public ImageSource PhotoImageSource
        {
            set
            {
                SetProperty(ref _PhotoImageSource, value);
            }
            get => _PhotoImageSource;
        }
        public string ImagePath
        {
            get { return _ImagePath; }
            set { SetProperty(ref _ImagePath, value); }
        }
        public string SignUP
        {
            get { return _SignUP; }
            set { SetProperty(ref _SignUP, value); }
        }
        public string PlaceConfirm
        {
            get { return _PlaceConfirm; }
            set { SetProperty(ref _PlaceConfirm, value); }
        }
        public string PlacePassword
        {
            get { return _PlacePassword; }
            set { SetProperty(ref _PlacePassword, value); }
        }
        public string PlaceLogin
        {
            get { return _PlaceLogin; }
            set { SetProperty(ref _PlaceLogin, value); }
        }
        public string PlaceLastName
        {
            get { return _PlaceLastName; }
            set { SetProperty(ref _PlaceLastName, value); }
        }
        public string PlaceName
        {
            get { return _PlaceName; }
            set { SetProperty(ref _PlaceName, value); }
        }
        public string PlacePhone
        {
            get { return _PlacePhone; }
            set { SetProperty(ref _PlacePhone, value); }
        }

        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        public string LastName
        {
            get { return _LastName; }
            set { SetProperty(ref _LastName, value); }
        }
        public string Login
        {
            get { return _Login; }
            set { SetProperty(ref _Login, value); }
        }
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }
        public string Confirm
        {
            get { return _Confirm; }
            set { SetProperty(ref _Confirm, value); }
        }
        public string Phone
        {
            get { return _Phone; }
            set { SetProperty(ref _Phone, value); }
        }
        #endregion
        #region--ctor
        public SignUpPageViewModel(INavigationService navigationService, IUserDialogs userDialogs, IMedia media) :base(navigationService,userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            _media = media;

            Title = "SignUP Page";
            PhotoImageSource = "pic_profile.png";
            PlaceName = "Name";
            PlaceLastName = "Surname";
            PlaceLogin = "Login";
            PlacePhone = "Phone number";
            PlacePassword = "Password";
            PlaceConfirm = "Confirm Password";
            SignUP = "SignUP";
        }
        #endregion

        #region--camera/gallery

        public ICommand ImageCommand => new Command(OnImageCommand);
        private void OnImageCommand()
        {

            _userDialogs = UserDialogs.Instance;
            ActionSheetConfig config = new ActionSheetConfig();

            List<ActionSheetOption> Options = new List<ActionSheetOption>();
            Options.Add(new ActionSheetOption("Gallery", () => FromGalleryAsync(), "ic_collections_black.png"));
            Options.Add(new ActionSheetOption("Camera", () => FromCameraAsync(), "ic_camera_alt_black.png"));
            ActionSheetOption cancel = new ActionSheetOption("Cancel", null, null);

            config.Options = Options;
            config.Cancel = cancel;

            _userDialogs.ActionSheet(config);
        }

        public async void FromGalleryAsync()
        {
            var image = await _media.PickPhotoAsync();
            if (image != null)
            {
                ImagePath = image.Path;
                PhotoImageSource = ImageSource.FromStream(() => image.GetStream());
            }
        }
        public async void FromCameraAsync()
        {
            var image = await _media.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Name = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.jpg",
                SaveToAlbum = true
            });

            if (image != null)
            {
                ImagePath = image.Path;
                PhotoImageSource = ImageSource.FromStream(() => image.GetStream());
            }
        }
        #endregion

        #region--register
        public ICommand SignUPCommand => new Command(OnSignUPCommand);
        private async void OnSignUPCommand()
        {
            if (!string.IsNullOrEmpty(Login))
            {
                RegistrationSuccess();
            }
            else
            {
                await _userDialogs.AlertAsync("Fields cannot be empty", null, "OK");
            }
        }

        private async void RegistrationSuccess()
        {
            var param = new NavigationParameters();
            param.Add("user", Login);
            await _navigationService.NavigateAsync(nameof(SignInPage), param);
        }

        #endregion
    }
}
