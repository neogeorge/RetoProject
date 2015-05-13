using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reto.Class
{
    public class BackendUser : BaseClass
    {
        /// <summary>
        /// 會員ID
        /// </summary>
        [Key, StringLength(20)]
        public string UserId { get; set; }

        /// <summary>
        /// 登入帳號
        /// </summary>
        [Required(ErrorMessage = "登入帳號不可為空"), StringLength(30)]
        public string UserLoginId { get; set; }

        /// <summary>
        /// 電子郵件
        /// </summary>
        [Required(ErrorMessage = "電子郵件不可為空"), StringLength(150)]
        public string Email { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [Required(ErrorMessage = "密碼不可為空"), StringLength(150)]
        public string Password { get; set; }

        /// <summary>
        /// 會員名稱
        /// </summary>
        [Required(ErrorMessage = "會員名稱不可為空"), StringLength(30)]
        public string Name { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        //[Required]
        public Boolean Sex { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public DefaultStatus Status { get; set; }

        /// <summary>
        /// 是否鎖住
        /// </summary>
        public Boolean IsLock { get; set; }

        /// <summary>
        /// 是否刪除
        /// </summary>
        //[Required]
        public Boolean IsDeleted { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 建立者
        /// </summary>
        [Required, StringLength(20)]
        public string CreateUser { get; set; }

        /// <summary>
        /// 修改時間
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>
        [StringLength(20)]
        public string UpdateUser { get; set; }
    }
}
