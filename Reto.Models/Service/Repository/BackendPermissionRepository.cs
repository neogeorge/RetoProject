﻿using AutoMapper;
using Reto.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;

namespace Reto.Models
{
    public class BackendPermissionRepository : BaseModel, IBackendPermissionRepository
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

        public BackendPermissionRepository(IBackendLogFactory logFactory)
        {
            _logFactory = logFactory;
        }

        #endregion

        #region Query 
        #endregion

        #region Add
        /// <summary>
        /// 新增權限
        /// </summary>
        /// <param name="permission">Permission Class</param>
        public void Add(BackendPermission permission)
        {
            string desc = @"新增權限";
            string functionName = @"BackendPermissionRepository/Add";

            try
            {
                permission.PermissionId = RetoSPViewDB.sp_NewBackendPermissionId().FirstOrDefault();
                var addItem = Mapper.Map<DataBase.BackendPermission>(permission);
                RetoDB.BackendPermission.Add(addItem);
                int count = RetoDB.SaveChanges();
                permission = Mapper.Map<BackendPermission>(addItem);
                permission.Success = (count > 0);
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