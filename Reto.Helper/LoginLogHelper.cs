using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reto.Class;
using Reto.Models;

namespace Reto.Helper
{
    public static class LoginLogHelper
    {
        private static IBackendLoginLogRespsitory loginLogRepo = new BackendLoginLogRespsitory();

        public static void Record(LoginStatus status, BackendLoginLog log)
        {
            try
            {
                loginLogRepo.Add(ref log);
                if(!log.Success)
                    throw new Exception("Add Login Log Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
