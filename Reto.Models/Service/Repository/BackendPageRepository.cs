using AutoMapper;
using Reto.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;

namespace Reto.Models
{
    public class BackendPageRepository : BaseModel, IBackendPageRepository
    {
        #region 建構式
        private IBackendLogFactory _logFactory;

        public IBackendLogFactory logFactory
        {
            get
            {
                return _logFactory;
            }
            set
            {
                _logFactory = value;
            }
        }

        public BackendPageRepository(IBackendLogFactory logFactory)
        {
            _logFactory = logFactory;
        }

        #endregion

        #region Query
        #endregion

        #region Add
        /// <summary>
        /// 新增頁面
        /// </summary>
        /// <param name="page">Page Class</param>
        public void Add(ref BackendPage page)
        {
            string desc = @"新增頁面";
            string functionName = @"BackendPageRepository/Add";

            try
            {
                page.PageId = RetoSPViewDB.sp_NewBackendPageId().FirstOrDefault();
                var addItem = Mapper.Map<DataBase.BackendPage>(page);
                RetoDB.BackendPage.Add(addItem);
                int count = RetoDB.SaveChanges();
                page.Success = (count > 0);
                logFactory.Success(this.logInfo, functionName, desc);
            }
            catch (Exception ex)
            {
                //若是Entity error則直接回傳Entity error message
                if (ex is EntityException)
                {
                    logFactory.Error(this.logInfo, ex.InnerException, functionName, desc);
                    throw ex.InnerException;
                }
                else
                {
                    logFactory.Error(this.logInfo, ex, functionName, desc);
                    throw ex; //若error則直接回傳error message
                }
            }
        }
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}
