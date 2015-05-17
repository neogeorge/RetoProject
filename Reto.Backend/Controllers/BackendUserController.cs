using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Reto.Class;
using Reto.Helper;
using Reto.Models;
using Reto.Backend.Models;

namespace Reto.Backend.Controllers
{
    public class BackendUserController : BaseController
    {
        #region 建構式
        private IBackendUserRepository _userRepository;

        public IBackendUserRepository userRepo
        {
            get
            {
                return _userRepository;
            }
            set
            {
                _userRepository = value;
            }
        }

        public BackendUserController(IBackendUserRepository userReposiotry)
        {
            _userRepository = userReposiotry;
        }
        #endregion

        [HttpGet]
        [BackendAuthorize]
        public ActionResult Index(BackendUser model, int? page = 1)
        {
            this.List(model, page);
            return View();
        }

        [HttpPost]
        [BackendAuthorize]
        public ActionResult List(BackendUser model, int? page = 1)
        {
            try
            {
                int totalCount = 0;
                Dictionary<string, object> dic = new Dictionary<string, object>();
                if (!string.IsNullOrEmpty(model.Name))
                    dic.Add("Name", model.Name);

                SearchModel search = new SearchModel() 
                                    {
                                        Dic = dic, 
                                        PageIndex = page.HasValue ? page.Value : 1,
                                        PageSize = base.PageSize
                                    };

                var records = userRepo.GetUserList(search, ref totalCount);

                return PartialView("_List", base.PagedList(records, search.PageIndex, totalCount));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [BackendAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [BackendAuthorize]
        public ActionResult Create(BackendUser model)
        {
            try
            {
                userRepo.Add(ref model);
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}