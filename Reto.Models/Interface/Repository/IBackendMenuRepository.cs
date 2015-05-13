using Reto.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Models
{
    public interface IBackendMenuRepository
    {
        #region Query
        /// <summary>
        /// 依帳號取得Menu List
        /// </summary>
        /// <param name="account">帳號/Email</param>
        /// <param name="IsEmail">是否為Email</param>
        /// <returns>List<BackendMenuPage></returns>
        List<BackendMenuPage> GetMenuPageListByUser(string account, bool IsEmail);
        #endregion

        #region Add
        /// <summary>
        /// 新增選單
        /// </summary>
        /// <param name="menu">Menu Class</param>
        void Add(ref BackendMenu menu);
        #endregion
    }
}
