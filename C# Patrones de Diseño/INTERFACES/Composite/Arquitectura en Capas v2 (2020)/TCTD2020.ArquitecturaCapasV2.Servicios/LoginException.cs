using System;

namespace TCTD2020.ArquitecturaCapasV2.Servicios
{
    public class LoginException : Exception
    {
        public LoginResult Result;

      public LoginException(LoginResult result)
        {
            Result = result;
        }
    
    }
}
