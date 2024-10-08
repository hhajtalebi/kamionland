using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace AccountManagement.Configuration.Permission
{
    public static class AccountPermissions
    {
        //Account
        public const int ListAccount = 60;
        public const int SearchAccount = 61;
        public const int CreateAccount = 62;
        public const int EditAccount = 63;
        //Roles
        public const int ListRoles = 64;
        public const int CreateRoles = 65;
        public const int EditRoles = 66;

    }
}
