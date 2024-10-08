

using _0_Framework.Domain;
using AccountManagement.Application.Contracts.AccountApplication;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<long, Account>
    {
        Account GetBy(string username);
        Account GetByMobile(string mobile);
        Account GetByCode(string code);
        EditAccount GetDetails(long id);
        List<AccountViewModel> GetAccounts();
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        long AccountCount();
        public AccountViewModel GetAccountBy(string Mobile);
    }
}
