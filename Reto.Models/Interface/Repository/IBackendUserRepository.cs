using Reto.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Models
{
    public interface IBackendUserRepository
    {
        #region Query
        /// <summary>
        /// 依帳號或EMail, 密碼取得使用者資料
        /// </summary>
        /// <param name="account">帳號/Email</param>
        /// <param name="password">密碼</param>
        /// <param name="IsEmail">是否為Eamil</param>
        /// <returns>BackendUser</returns>
        BackendUser GetUser(string account, string password, bool IsEmail);

        /// <summary>
        /// 依條件取得使用者資料列
        /// </summary>
        /// <param name="search"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<BackendUser> GetUserList(SearchModel search, ref int totalCount);
        #endregion

        #region Add
        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="user">User Class</param>
        void Add(ref BackendUser user);
        #endregion
    }
}
