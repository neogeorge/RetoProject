using Reto.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Models
{
    public interface IBackendLogRepository
    {
        #region Query
        /// <summary>
        /// 取得超過六個月以上的LogID
        /// </summary>
        /// <returns>List<int></returns>
        List<int> GetOverTimeLogCount();
        #endregion

        #region Add
        /// <summary>
        /// 新增後台Log資料
        /// </summary>
        /// <param name="log"></param>
        void Add(ref BackendLog log);
        #endregion

        #region Update
        #endregion

        #region Dlete
        /// <summary>
        /// 刪除Log
        /// </summary>
        /// <param name="logIdList">LogID List</param>
        void Delete(List<int> logIdList);
        #endregion
    }
}
