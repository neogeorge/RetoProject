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
    public class BackendPermissionMenuRepository : BaseModel, IBackendPermissionMenuRepository
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

        public BackendPermissionMenuRepository(IBackendLogFactory logFactory)
        {
            _logFactory = logFactory;
        }

        #endregion

        #region Query
        #endregion

        #region Add
        /// <summary>
        /// 新增權限選單
        /// </summary>
        /// <param name="permissionMenu">PermissionMenu Class</param>
        public void Add(ref BackendPermissionMenu permissionMenu)
        {
            string desc = @"新增權限選單";
            string functionName = @"BackendPermissionMenuRepository/Add";

            try
            {
                var addItem = Mapper.Map<DataBase.BackendPermissionMenu>(permissionMenu);
                RetoDB.BackendPermissionMenu.Add(addItem);
                int count = RetoDB.SaveChanges();
                permissionMenu = Mapper.Map<BackendPermissionMenu>(addItem);
                permissionMenu.Success = (count > 0);
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
