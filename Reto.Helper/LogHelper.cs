using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reto.Class;
using Reto.Models;

namespace Reto.Helper
{
    public class LogHelper
    {
        private static IBackendLogRepository logRepo = new BackendLogRepository();

        public static void Info(BackendLog log, string functionName = null, string desc = null, string eventStr = null, string param = null)
        {
            Execute(LogStatus.Info, log, functionName, desc, eventStr, param);
        }

        public static void Success(BackendLog log, string functionName = null, string desc = null, string eventStr = null, string param = null)
        {
            Execute(LogStatus.Success, log, functionName, desc, eventStr, param);
        }

        public static void Error(BackendLog log, Exception exception = null, string functionName = null, string desc = null, string eventStr = null, string param = null)
        {
            Execute(LogStatus.Error, log, functionName, desc, eventStr, param, exception);
        }

        private static void Execute(LogStatus status, BackendLog log, string functionName = null, string desc = null, string eventStr = null, string param = null, Exception exception = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(functionName))
                    log.FunctionName = log.ActionLink;

                if (!string.IsNullOrEmpty(desc))
                    log.Description = desc;

                if (!string.IsNullOrEmpty(eventStr))
                    log.Event = eventStr;

                if (!string.IsNullOrEmpty(param))
                    log.Paramer = param;

                switch (status)
                {
                    case LogStatus.Info:
                        log.Status = LogStatus.Info;
                        log.Message = string.Format("Info {0}", functionName);
                        break;
                    case LogStatus.Success:
                        log.Status = LogStatus.Success;
                        log.Message = string.Format("Execute {0} Success", functionName);
                        break;
                    case LogStatus.Error:
                        log.Status = LogStatus.Error;
                        log.Message = exception.Message;
                        break;
                }
                logRepo.Add(ref log);
                if (!log.Success)
                    throw new Exception("Add Log Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
