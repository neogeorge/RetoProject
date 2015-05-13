using Reto.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Models
{
    public interface IBackendPermissionMenuRepository
    {
        #region Query
        #endregion

        #region Add
        /// <summary>
        /// 新增權限選單
        /// </summary>
        /// <param name="permissionMenu">PermissionMenu Class</param>
        void Add(ref BackendPermissionMenu permissionMenu);
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}
