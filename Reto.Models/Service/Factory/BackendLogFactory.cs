using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reto.Class;

namespace Reto.Models
{
    public class BackendLogFactory : IBackendLogFactory
    {
        #region 建構式
        private static IBackendLogRepository _logRepository;

        public static IBackendLogRepository logRepo
        {
            get
            {
                return _logRepository;
            }
            set
            {
                _logRepository = value;
            }
        }

        public BackendLogFactory(IBackendLogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        #endregion

        #region Query
        #endregion

        #region Add
        public void Info(BackendLog log, string functionName = null, string desc = null, string eventStr = null, string param = null)
        {
            Execute(LogStatus.Info, log, functionName, desc, eventStr, param);
        }

        public void Success(BackendLog log, string functionName = null, string desc = null, string eventStr = null, string param = null)
        {
            Execute(LogStatus.Success, log, functionName, desc, eventStr, param);
        }

        public void Error(BackendLog log, Exception exception = null, string functionName = null, string desc = null, string eventStr = null, string param = null)
        {
            Execute(LogStatus.Error, log, functionName, desc, eventStr, param, exception);
        }
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion

        #region 私用Function
        private void Execute(LogStatus status, BackendLog log, string functionName = null, string desc = null, string eventStr = null, string param = null, Exception exception = null)
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
        #endregion
    }
}
