using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.Entity.Accounts;
using lab2.ServiceLevel;

namespace lab2.Factories
{
    static class PlayerFactory
    {
        public static GameAccount CreatePlayer(int id, string username, string password, string accType)
        {
            switch (accType.ToLower())
            {
                case "standart":
                    return new StandartAccount(id, username, password);

                case "vip":
                    return new VIPAccount(id, username, password);

                case "winstreak":
                    return new WinStreakAccount(id, username, password);

                default:
                    throw new Exception("Invalid account type");
            }
        }
    }
}