using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Reto.Class;

namespace Reto.Models
{
    public class BaseModel
    {
        private DataBase.RetoEntities _retoDB = new DataBase.RetoEntities();
        private DataBase.RetoSPViewEntities _retoSPViewDB = new DataBase.RetoSPViewEntities();
        public BackendLog _log;

        public DataBase.RetoEntities RetoDB
        {
            get
            {
                if (_retoDB == null)
                    _retoDB = new DataBase.RetoEntities();

                return _retoDB;
            }
            set
            {
                _retoDB = value;
            }
        }

        public DataBase.RetoSPViewEntities RetoSPViewDB
        {
            get
            {
                if(_retoSPViewDB == null)
                    _retoSPViewDB = new DataBase.RetoSPViewEntities();

                return _retoSPViewDB;
            }
            set
            {
                _retoSPViewDB = value;
            }
        }

        public BackendLog logInfo
        {
            get
            {
                if (_log == null)
                    _log = (BackendLog)HttpContext.Current.Session["LoginInfo"] ?? new BackendLog();

                return _log;
            }
            set
            {
                _log = value;
            }
        }
    }
}
