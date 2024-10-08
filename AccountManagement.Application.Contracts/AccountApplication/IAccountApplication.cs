
using _0_Framework.Application;
using System.Collections.Generic;
using AccountManagement.Application.Contracts.AccountApplication;

namespace AccountManagement.Application.Contracts.AccountApplication
{
    public interface IAccountApplication
    {
        AccountViewModel GetAccountBy(long id);
        AccountViewModel GetAccountBy(string Mobile);
        OperationResulte Register(RegisterAccount command);
        OperationResulte Edit(EditAccount command);
        OperationResulte ChangePassword(ChangePassword command);
        OperationResulte changeSecurityCode(ChangeSecurityCode command);
        OperationResulte Login(Login command);
        OperationResulte LoginFromMobile(LoginFromMobile command);
        EditAccount GetDetails(long id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        void Logout();
        List<AccountViewModel> GetAccounts();
        long AccountCount();
    }
}
