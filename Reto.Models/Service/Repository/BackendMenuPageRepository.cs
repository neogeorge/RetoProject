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
    public class BackendMenuPageRepository : BaseModel, IBackendMenuPageRepository
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

        public BackendMenuPageRepository(IBackendLogFactory logFactory)
        {
            _logFactory = logFactory;
        }

        #endregion

        #region Query
        #endregion

        #region Add
        /// <summary>
        /// 新增選單頁面
        /// </summary>
        /// <param name="menuPage">MenuPage Calse</param>
        public void Add(ref BackendMenuPage menuPage)
        {
            string desc = @"新增選單頁面";
            string functionName = @"BackendMenuPageRepository/Add";

            try
            {
                var addItem = Mapper.Map<DataBase.BackendMenuPage>(menuPage);
                RetoDB.BackendMenuPage.Add(addItem);
                int count = RetoDB.SaveChanges();
                menuPage = Mapper.Map<BackendMenuPage>(addItem);
                menuPage.Success = (count > 0);
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
