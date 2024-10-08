using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.RoleApplication
{
    public class CreateRole
    {
        public string Name { get; set; }
        public List<int> Permissions { get; set; }
    }

}
