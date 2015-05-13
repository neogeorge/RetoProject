using AutoMapper;
using Reto.Class;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Models
{
    public class BackendLoginLogRespsitory : BaseModel, IBackendLoginLogRespsitory
    {
        #region Query
        /// <summary>
        /// 取得超過六個月以上的LoginLogID
        /// </summary>
        /// <returns>List<int></returns>
        public List<int> GetOverTimeLogCount()
        {
            try
            {
                DateTime lastSex = DateTime.Now.AddMonths(-6);
                return RetoDB.BackendLoginLog.Where(x => x.CreateDate < lastSex)
                                                  .Select(y => y.LoginLogId).ToList();
            }
            catch (Exception ex)
            {
                //若是Entity error則直接回傳Entity error message
                if (ex is EntityException)
                    throw ex.InnerException;
                else
                    throw ex; //若error則直接回傳error message
            }
        }
        #endregion

        #region Add
        /// <summary>
        /// 新增後台Login Log資料
        /// </summary>
        /// <param name="log">Login Log Class</param>
        public void Add(ref BackendLoginLog log)
        {
            try
            {
                var addItem = Mapper.Map<DataBase.BackendLoginLog>(log);
                addItem.CreateDate = DateTime.Now;
                RetoDB.BackendLoginLog.Add(addItem);
                int count = RetoDB.SaveChanges();
                log = Mapper.Map<BackendLoginLog>(addItem);
                log.Success = (count > 0);

                //檢查Log是否超過六個月, 若Log超過六個月就執行刪除
                this.Delete(this.GetOverTimeLogCount());
            }
            catch (Exception ex)
            {
                //若是Entity error則直接回傳Entity error message
                if (ex is EntityException)
                    throw ex.InnerException;
                else
                    throw ex; //若error則直接回傳error message
            }
        }
        #endregion

        #region Update
        #endregion 

        #region Delete
        /// <summary>
        /// 刪除Log List
        /// </summary>
        /// <param name="logIdList">LoginLogID List</param>
        public void Delete(List<int> logIdList)
        {
            try
            {
                var query = RetoDB.BackendLoginLog.Where(x => logIdList.Contains(x.LoginLogId));
                foreach(var item in query)
                {
                    RetoDB.BackendLoginLog.Remove(item);
                }
            }
            catch (Exception ex)
            {
                //若是Entity error則直接回傳Entity error message
                if (ex is EntityException)
                    throw ex.InnerException;
                else
                    throw ex; //若error則直接回傳error message
            }
        }
        #endregion
    }
}
