using FubuMVC.Core.Continuations;
using FubuMVC.Core.Security.AntiForgery;
using FubuMVC.HelloFubuSpark.Controllers.Home;
using FubuMVC.HelloFubuSpark.Services;

namespace FubuMVC.HelloFubuSpark.Controllers.Login
{
    public class LoginController
    {
        private readonly IHttpSession _session;

        public LoginController(IHttpSession session)
        {
            _session = session;
        }

		[AntiForgeryToken(Salt = "Login")]
        public FubuContinuation Login(LoginRequestModel model)
        {
            _session[CurrentLoginStatus.Key] = new CurrentLoginStatus {UserName = "Cookie Monster"};

            return FubuContinuation.RedirectTo(new HomeInputModel());
        }

        public FubuContinuation Logoff(LogoffRequestModel model)
        {
            _session.Clear();

            return FubuContinuation.RedirectTo(new HomeInputModel());
        }
    }

    public class LoginRequestModel
    {
    }

    public class LogoffRequestModel
    {
    }
}