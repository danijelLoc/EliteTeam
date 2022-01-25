using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.BaseLib
{
    public interface IView
    {
        void CloseView();
        void ShowMessage(string message);
    }
}
