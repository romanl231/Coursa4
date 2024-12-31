using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.DbContext;
using lab2.Entity.Accounts;
using lab2.Entity.Games;

namespace lab2.CommandManager.Interfaces
{
    interface ICommand
    {
        void Execute();
        string GetDescription();
    }
}
