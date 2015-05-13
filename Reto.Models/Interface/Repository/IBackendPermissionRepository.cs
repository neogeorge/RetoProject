using Reto.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Models
{
    public interface IBackendPermissionRepository
    {
        #region Query
        #endregion

        #region Add
        /// <summary>
        /// 新增權限
        /// </summary>
        /// <param name="permission">Permission Class</param>
        void Add(BackendPermission permission);
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}
