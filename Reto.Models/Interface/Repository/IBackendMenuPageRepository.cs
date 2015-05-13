using Reto.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Models
{
    public interface IBackendMenuPageRepository
    {
        #region Query
        #endregion

        #region Add
        /// <summary>
        /// 新增選單頁面
        /// </summary>
        /// <param name="menuPage">MenuPage Calse</param>
        void Add(ref BackendMenuPage menuPage);
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}
