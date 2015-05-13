using AutoMapper;
using Reto.Class;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Models
{
    public class BackendMenuRepository : BaseModel, IBackendMenuRepository
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

        public BackendMenuRepository(IBackendLogFactory logFactory)
        {
            _logFactory = logFactory;
        }

        #endregion

        #region Query
        /// <summary>
        /// 依帳號取得Menu List
        /// </summary>
        /// <param name="account">帳號/Email</param>
        /// <param name="IsEmail">是否為Email</param>
        /// <returns>List<BackendMenuPage></returns>
        public List<BackendMenuPage> GetMenuPageListByUser(string account, bool IsEmail)
        {
            string desc = @"依帳號取得Menu List";
            string functionName = @"BackendMenuRepository/GetMenuPageListByUser";

            try
            {
                List<BackendMenuPage> result = new List<BackendMenuPage>();
                var query = RetoSPViewDB.sp_GetMenuByUser(account, (IsEmail ? 1 : 0));

                foreach(var item in query)
                {
                    BackendMenuPage menuPage = new BackendMenuPage();
                    
                    BackendMenu menu = new BackendMenu();
                    menu.MenuId = item.MenuId;
                    menu.ParentId = item.ParentId;
                    menu.Name = item.Name;
                    menu.Level = item.Level;
                    menu.LinkType = item.LinkType;
                    menu.Sort = item.Sort;
                    
                    BackendPage page = new BackendPage();
                    page.PageId = item.PageId;
                    page.Controller = item.Controller;
                    page.Action = item.Action;

                    menuPage.Menu = menu;
                    menuPage.Page = page;
                    result.Add(menuPage);
                }

                logFactory.Success(this.logInfo, functionName, desc);

                return result;
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
        /// 新增選單
        /// </summary>
        /// <param name="menu">Menu Class</param>
        public void Add(ref BackendMenu menu)
        {
            string desc = @"新增選單";
            string functionName = @"BackendMenuRepository/Add";

            try
            {
                menu.MenuId = RetoSPViewDB.sp_NewBackendMenuId().FirstOrDefault();
                var addItem = Mapper.Map<DataBase.BackendMenu>(menu);
                RetoDB.BackendMenu.Add(addItem);
                int count = RetoDB.SaveChanges();
                menu = Mapper.Map<BackendMenu>(addItem);
                menu.Success = (count > 0);
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
        #endregion

        #region Delete
        #endregion
    }
}
