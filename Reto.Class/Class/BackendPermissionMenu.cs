using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reto.Class
{
    public class BackendPermissionMenu : BaseClass
    {
        /// <summary>
        /// 選單權限ID
        /// </summary>
        [Key]
        public int PermissionId { get; set; }

        /// <summary>
        /// 選單
        /// </summary>
        public BackendMenu MenuId { get; set; }

        /// <summary>
        /// 權限
        /// </summary>
        public BackendPermission Permission { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        [Required]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 建立者
        /// </summary>
        [Required, StringLength(20)]
        public string CreateUser { get; set; }
    }
}
