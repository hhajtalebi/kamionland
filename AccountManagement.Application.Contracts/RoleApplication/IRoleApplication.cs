using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.RoleApplication
{
    public interface IRoleApplication
    {
        OperationResulte Create(CreateRole command);
        OperationResulte Edit(EditRole command);
        List<RoleViewModel> List();
        EditRole GetDetails(long id);
    }
}
