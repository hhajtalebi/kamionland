using _0_Framework.Domain;
using AccountManagement.Application.Contracts.RoleApplication;


namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepository<long, Role>
    {
        List<RoleViewModel> List();
        EditRole GetDetails(long id);
    }
}
