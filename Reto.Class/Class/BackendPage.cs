using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reto.Class
{
    public class BackendPage : BaseClass
    {
        /// <summary>
        /// 頁面ID
        /// </summary>
        [Key, StringLength(10)]
        public string PageId { get; set; }

        /// <summary>
        /// 頁面名稱
        /// </summary>
        [Required(ErrorMessage = "頁面名稱不可為空"), StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public DefaultStatus Status { get; set; }

        /// <summary>
        /// 是否刪除
        /// </summary>
        [Required]
        public Boolean IsDeleted { get; set; }

        /// <summary>
        /// 路徑
        /// </summary>
        [StringLength(200)]
        public string LinkAddress { get; set; }

        /// <summary>
        /// 區域
        /// </summary>
        [StringLength(50)]
        public string Area { get; set; }

        /// <summary>
        /// 控制項
        /// </summary>
        [StringLength(50)]
        public string Controller { get; set; }

        /// <summary>
        /// 動作
        /// </summary>
        [StringLength(50)]
        public string Action { get; set; }

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
