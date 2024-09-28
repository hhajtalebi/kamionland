namespace _0_Framework.Infrastructure
{
    public static class Roles
    {
        public const string ContentUploader = "4";
        public const string Administrator = "1";
        public const string SystemUser = "5";
        public const string ColleagueUser = "6";
        
        public static string GetRoleBy(long id)
        {
            switch (id)
            {
                case 1:
                    return "مدیرسیستم";
                case 2:
                    return "مدیر فروش ";
                case 3:
                    return "کاربر معمولی";
                case 4:
                    return "فروشنده همکار";
                default:
                    return "";
            }
        }
    }
}
