using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrisoleRed.Services.Modes;

namespace TrisoleRed.Services.Interfaces
{
    public interface IUserInterface
    {
        bool LogIn(LogIn model);
        bool SignIn(Sign model);
    }
}
