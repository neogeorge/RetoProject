using Reto.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Models
{
    public interface IBackendPageRepository
    {
        #region Query
        #endregion

        #region Add
        /// <summary>
        /// 新增頁面
        /// </summary>
        /// <param name="page">Page Class</param>
        void Add(ref BackendPage page);
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}
