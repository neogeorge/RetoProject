using AutoMapper;
using Reto.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;
using System.Web;

namespace Reto.Models
{
    public class BackendUserRepository : BaseModel, IBackendUserRepository
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

        public BackendUserRepository(IBackendLogFactory logFactory)
        {
            _logFactory = logFactory;
        }

        #endregion

        #region Query

        /// <summary>
        /// 依帳號或EMail, 密碼取得使用者資料
        /// </summary>
        /// <param name="account">帳號/Email</param>
        /// <param name="password">密碼</param>
        /// <param name="IsEmail">是否為Eamil</param>
        /// <returns>BackendUser</returns>
        public BackendUser GetUser(string account, string password, bool IsEmail)
        {
            string desc = @"依帳號或EMail, 密碼取得使用者資料";
            string functionName = @"BackendUserRepository/GetUser";

            try
            {
                DataBase.BackendUser query;
                if (IsEmail)
                    query = RetoDB.BackendUser.FirstOrDefault(x => x.Email == account && x.Password == password);
                else
                    query = RetoDB.BackendUser.FirstOrDefault(x => x.UserLoginId == account && x.Password == password);
                
                this.logInfo.CreateUser = query.UserLoginId;
                logFactory.Success(this.logInfo, functionName, desc);
                return Mapper.Map<BackendUser>(query);
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

        /// <summary>
        /// 依帳號取得使用者資料
        /// </summary>
        /// <param name="account">帳號</param>
        /// <returns></returns>
        public BackendUser GetUser(string account)
        {
            string desc = @"依帳號取得使用者資料";
            string functionName = @"BackendUserRepository/GetUser";

            try
            {
                var query = RetoDB.BackendUser.FirstOrDefault(x => x.UserLoginId == account);

                this.logInfo.CreateUser = query.UserLoginId;
                logFactory.Success(this.logInfo, functionName, desc);
                return Mapper.Map<BackendUser>(query);
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

        /// <summary>
        /// 依條件取得使用者資料列
        /// </summary>
        /// <param name="search"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BackendUser> GetUserList(SearchModel search, ref int totalCount)
        {
            string desc = @"依條件取得使用者資料列";
            string functionName = @"BackendUserRepository/GetUserList";

            try
            {
                var query = RetoDB.BackendUser.AsQueryable();

                if(search.Dic != null)
                {
                    foreach(var key in search.Dic.Keys)
                    {
                        string sValue = search.Dic[key].ToString();
                        if(!string.IsNullOrEmpty(sValue))
                        {
                            switch(key)
                            {
                                case "Name":
                                    query = query.Where(x => x.Name.Contains(sValue));
                                    break;
                            }
                        }
                    }
                }

                totalCount = query.Count();

                if (search.PageSize > 0)
                    query = query.OrderByDescending(x => x.CreateDate).Skip((search.PageIndex - 1) * search.PageSize).Take(search.PageSize);

                logFactory.Success(this.logInfo, functionName, desc);
                return Mapper.Map<List<BackendUser>>(query.ToList());
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

        #region Add
        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="user">User Class</param>
        public void Add(ref BackendUser user)
        {
            string desc = @"新增使用者";
            string functionName = @"BackendUserRepository/Add";

            try
            {
                user.UserId = RetoSPViewDB.sp_NewBackendUserId().FirstOrDefault();
                var addItem = Mapper.Map<DataBase.BackendUser>(user);
                RetoDB.BackendUser.Add(addItem);
                int count = RetoDB.SaveChanges();
                user = Mapper.Map<BackendUser>(addItem);
                user.Success = (count > 0);
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
        /// <summary>
        /// 修改使用者
        /// </summary>
        /// <param name="user">User Class</param>
        /// <returns></returns>
        public bool Update(BackendUser user)
        {
            string desc = @"修改使用者";
            string functionName = @"BackendUserRepository/Update";

            try
            {
                var query = RetoDB.BackendUser.FirstOrDefault(x=>x.UserLoginId == user.UserLoginId);
                int count = 0;
                if(query != null)
                {
                    query.Name = user.Name;
                    query.Sex = user.Sex;
                    query.Email = user.Email;
                    query.IsLock = user.IsLock;
                    query.UpdateUser = query.UpdateUser;
                    query.UpdateDate = DateTime.Now;

                    count = RetoDB.SaveChanges();
                }

                logFactory.Success(this.logInfo, functionName, desc);
                return (count > 0);
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

        #region Delete
        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="userLoginId">帳號</param>
        /// <returns></returns>
        public bool Delete(string userLoginId)
        {
            string desc = @"刪除使用者";
            string functionName = @"BackendUserRepository/Delete";

            try
            {
                var query = RetoDB.BackendUser.FirstOrDefault(x => x.UserLoginId == userLoginId);
                RetoDB.BackendUser.Remove(query);
                int count = RetoDB.SaveChanges();
                logFactory.Success(this.logInfo, functionName, desc);
                return (count > 0);
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
    }
}
