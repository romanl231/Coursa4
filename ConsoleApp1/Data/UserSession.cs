using lab2.Entity.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Data
{
    static class UserSession
    {
        public static GameAccount CurrentUser { get; set; }
        public static string CurrPass { get; set; } = "1234";
        public static UserRole Role { get; private set; } = UserRole.Guest;

        public static void SetUserRole(UserRole role)
        {
            Role = role;
        }

        public static void ResetUserRole()
        {
            Role = UserRole.Guest;
        }

        public enum UserRole
        {
            Guest,
            User,
            Admin
        }
    }
}
