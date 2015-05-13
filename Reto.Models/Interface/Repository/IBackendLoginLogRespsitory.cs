using Reto.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Models
{
    public interface IBackendLoginLogRespsitory
    {
        #region Query
        /// <summary>
        /// 取得超過六個月以上的LoginLogID
        /// </summary>
        /// <returns>List<int></returns>
        List<int> GetOverTimeLogCount();
        #endregion

        #region Add
        /// <summary>
        /// 新增後台Login Log資料
        /// </summary>
        /// <param name="log">Login Log Class</param>
        void Add(ref BackendLoginLog log);
        #endregion

        #region Update
        #endregion

        #region Dlete
        /// <summary>
        /// 刪除Log List
        /// </summary>
        /// <param name="logIdList">LoginLogID List</param>
        void Delete(List<int> logIdList);
        #endregion
    }
}
