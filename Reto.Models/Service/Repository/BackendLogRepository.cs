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
    public class BackendLogRepository : BaseModel, IBackendLogRepository
    {
        #region Query
        /// <summary>
        /// 取得超過六個月以上的LogID
        /// </summary>
        /// <returns>List<int></returns>
        public List<int> GetOverTimeLogCount()
        {
            try
            {
                DateTime lastSex = DateTime.Now.AddMonths(-6);
                return RetoDB.BackendLog.Where(x => x.CreateDate < lastSex)
                                             .Select(y => y.LogId).ToList();
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
        /// 新增後台Log資料
        /// </summary>
        /// <param name="log">Log Class</param>
        public void Add(ref BackendLog log)
        {
            try
            {
                var addItem = Mapper.Map<DataBase.BackendLog>(log);
                addItem.CreateDate = DateTime.Now;
                RetoDB.BackendLog.Add(addItem);
                int count = RetoDB.SaveChanges();
                log = Mapper.Map<BackendLog>(addItem);
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
        /// <param name="logIdList">LogID List</param>
        public void Delete(List<int> logIdList)
        {
            try
            {
                var query = RetoDB.BackendLog.Where(x => logIdList.Contains(x.LogId));
                foreach(var item in query)
                {
                    RetoDB.BackendLog.Remove(item);
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
