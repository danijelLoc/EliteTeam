using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.BaseLib
{
    public class ExceptionHandler
    {
        public static void HandleBlock(Action block, IView messageView)
        {
            try
            {
                block();
            }
            catch (Exception exc)
            {
                messageView.ShowMessage(exc.Message);
            }
        }
    }
}
