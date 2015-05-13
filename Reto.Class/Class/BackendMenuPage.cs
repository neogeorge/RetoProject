using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reto.Class
{
    public class BackendMenuPage : BaseClass
    {
        /// <summary>
        /// 選單頁面ID
        /// </summary>
        [Key]
        public int MenuPageId { get; set; }

        /// <summary>
        /// 選單
        /// </summary>

        public BackendMenu Menu { get; set; }

        /// <summary>
        /// 頁面
        /// </summary>
        public BackendPage Page { get; set; }

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
