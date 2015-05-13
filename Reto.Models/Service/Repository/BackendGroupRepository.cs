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
    public class BackendGroupRepository : BaseModel, IBackendGroupRepository
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

        public BackendGroupRepository(IBackendLogFactory logFactory)
        {
            _logFactory = logFactory;
        }

        #endregion

        #region Query
        #endregion

        #region Add
        /// <summary>
        /// 新增群組
        /// </summary>
        /// <param name="group">Group Class</param>
        public void Add(ref BackendGroup group)
        {
            string desc = @"新增群組";
            string functionName = @"BackendGroupRepository/Add";

            try
            {
                group.GroupId = RetoSPViewDB.sp_NewBackendGroupId().FirstOrDefault();
                var addItem = Mapper.Map<DataBase.BackendGroup>(group);
                RetoDB.BackendGroup.Add(addItem);
                int count = RetoDB.SaveChanges();
                group.Success = (count > 0);
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
