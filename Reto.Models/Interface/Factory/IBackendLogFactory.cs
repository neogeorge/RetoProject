using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reto.Class;

namespace Reto.Models
{
    public interface IBackendLogFactory
    {
        void Info(BackendLog log, string functionName = null, string desc = null, string eventStr = null, string param = null);
        void Success(BackendLog log, string functionName = null, string desc = null, string eventStr = null, string param = null);
        void Error(BackendLog log, Exception exception = null, string functionName = null, string eventStr = null, string desc = null, string param = null);

    }
}
