using Reto.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Models
{
    public interface IBackendPermissionGroupRepository
    {
        #region Query
        #endregion

        #region Add
        /// <summary>
        /// 新增權限群組
        /// </summary>
        /// <param name="permissionGroup">PermissionGroup Class</param>
        void Add(ref BackendPermissionGroup permissionGroup);
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}
