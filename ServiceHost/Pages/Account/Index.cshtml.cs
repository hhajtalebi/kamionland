using _0_Framework.Application;
using _0_Framework.Application.AuthHelper;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.AccountApplication;
using AccountManagement.Application.Contracts.RoleApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ServiceHost.Pages.Account
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string LoginMessage { get; set; }

        [TempData]
        public string RegisterMessage { get; set; }



        private readonly IAccountApplication _accountApplication;
        private readonly IAuthHelper _AuthHelper;

        public IndexModel(IAccountApplication accountApplication, IAuthHelper AuthHelper)
        {
            _accountApplication = accountApplication;

            _AuthHelper = AuthHelper;

        }
        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(Login command)
        {
            var result = _accountApplication.Login(command);
            if (result.IsSuccedded)
            {
                return RedirectToPage("/Index");
            }

            return Redirect("~/Account");
        }
        public IActionResult OnPostLoginFromMobile(LoginFromMobile command)
        {
            var result = _accountApplication.LoginFromMobile(command);
            if (result.IsSuccedded)
            {
                return RedirectToPage("/Index");
            }
            return Redirect("~/Account");
        }
        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Index");
        }
        public IActionResult OnPostRegister(RegisterAccount command)
        {
            var account = _accountApplication.GetAccountBy(command.Mobile);
            command.Username = command.Mobile;
            command.RoleId = Convert.ToInt64(Roles.SystemUser);

            command.Roles = new List<RoleViewModel>() { new RoleViewModel()
                {
                    Id = Convert.ToInt64(Roles.SystemUser),
                    Name = Roles.GetRoleBy(Convert.ToInt64(Roles.SystemUser)),
                    CreationDate = DateTime.Now.ToFarsiFull(),
                    } };

            var result = _accountApplication.Register(command);
            if (result.IsSuccedded)
                return Redirect("/Account");
            RegisterMessage = result.Messege;
            return Redirect("/Account");
        }
    }
}
