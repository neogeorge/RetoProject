using Reto.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Models
{
    public interface IBackendGroupRepository
    {
        #region Query
        #endregion

        #region Add
        /// <summary>
        /// 新增群組
        /// </summary>
        /// <param name="group">Group Class</param>
        void Add(ref BackendGroup group);
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}
