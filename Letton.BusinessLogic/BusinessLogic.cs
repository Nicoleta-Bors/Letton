using Letton.BusinessLogic.Interfaces;

namespace Letton.BusinessLogic
{
    public class BusinessLogic
    {
          public ISession GetSessionBL()
          {
               return new SessionBL();
          }
    }
}
