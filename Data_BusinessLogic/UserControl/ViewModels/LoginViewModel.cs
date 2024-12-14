using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_BusinessLogic.Services;

namespace Data_BusinessLogic.UserControl.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private readonly IAuthService _authService;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
            LoginCommand = new RelayCommand(async () => await OnLoginAsync(), CanLogin);
            CancelCommand = new RelayCommand(OnCancel);
        }

        private string _login;
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public RelayCommand LoginCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        private bool CanLogin() => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);

        private async Task OnLoginAsync()
        {
            try
            {
                var user = await _authService.AuthenticateUserAsync(Login, Password);
                if (user != null)
                {
                    Done?.Invoke(user);  
                }
                else
                {
                    ShowErrorMessage("Invalid credentials");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        private void OnCancel()
        {
            Done?.Invoke(null);
        }

        private void ShowErrorMessage(string message)
        {
            Console.WriteLine(message);
        }

        public event Action<Users> Done;
    }
}
