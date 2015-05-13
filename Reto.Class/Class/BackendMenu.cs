using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reto.Class
{
    public class BackendMenu : BaseClass
    {
        /// <summary>
        /// 選單ID
        /// </summary>
        [Key, StringLength(10)]
        public string MenuId { get; set; }

        /// <summary>
        /// 父選單ID
        /// </summary>
        [StringLength(10)]
        public string ParentId { get; set; }

        /// <summary>
        /// 選單名稱
        /// </summary>
        [Required(ErrorMessage = "選單名稱不可為空"), StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public DefaultStatus Status { get; set; }

        /// <summary>
        /// 階級
        /// </summary>
        public Byte Level { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public Byte Sort { get; set; }

        /// <summary>
        /// 是否刪除
        /// </summary>
        [Required]
        public Boolean IsDeleted { get; set; }

        /// <summary>
        /// 連結類型
        /// </summary>
        public Byte LinkType { get; set; }

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
