using Api.Domain.ViewModels.Users;

namespace Api.Domain.ViewModels
{
    public class MainViewModel
    {
        public UserRegisterViewModel RegisterView { get; set; }

        public UserLoginViewModel LoginView { get; set; }

        public MainViewModel()
        {
            RegisterView = new UserRegisterViewModel();
            LoginView = new UserLoginViewModel();
        }
    }
}