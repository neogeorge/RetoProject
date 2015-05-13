using Reto.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Models
{
    public interface IBackendUserGroupRepository
    {
        #region Query
        #endregion

        #region Add
        /// <summary>
        /// 新增使用者群組
        /// </summary>
        /// <param name="userGroup">UserGroup Class</param>
        void Add(ref BackendUserGroup userGroup);
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}
