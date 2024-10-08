using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : EntityBase
    {
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public string Address { get; private set; }
       public string SecurityCode { get; private set; }
        public long RoleId { get; private set; }
        public Role Role { get; private set; }
        public string ProfilePhoto { get; private set; }

        public Account(string fullname, string username, string password, string mobile, string? address,
            long roleId, string profilePhoto,string securityCode)
        {
            Fullname = fullname;
            Username = username;
            Password = password;
            Mobile = mobile;
            RoleId = roleId;

            if (roleId == 0)
                RoleId = 3;
            
            ProfilePhoto = profilePhoto;
            Address = address;
            SecurityCode = securityCode;
           
        }

        public void Edit(string fullname, string username, string mobile,
            long roleId, string profilePhoto, string address, string securityCode)
        {
            Fullname = fullname;
            Username = username;
            Mobile = mobile;
            RoleId = roleId;

            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;
            Address = address;
            if (!string.IsNullOrWhiteSpace(securityCode))
                SecurityCode = securityCode;
           
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

        public void ChangeSecurityCode(string securityCode)
        { 
            SecurityCode=securityCode;
        }
    }
}
