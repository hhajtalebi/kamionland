using AccountManagement.Application.Contracts.AccountApplication;

namespace AccountManagement.Application.Contracts.AccountApplication
{
    public class EditAccount : RegisterAccount
    {
        public long Id { get; set; }
    }
}
