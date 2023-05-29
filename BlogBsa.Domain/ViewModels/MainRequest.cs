using BlogBsa.Domain.ViewModels.Users;

namespace BlogBsa.Domain.ViewModels
{
    public class MainRequest
    {
        public UserRegisterViewModel RegisterView { get; set; }

        public UserLoginViewModel LoginView { get; set; }

        public MainRequest()
        {
            RegisterView = new UserRegisterViewModel();
            LoginView = new UserLoginViewModel();
        }
    }
}
