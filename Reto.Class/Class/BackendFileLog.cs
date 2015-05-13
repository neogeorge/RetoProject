using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reto.Class
{
    public class BackendFileLog : BaseClass
    {
        /// <summary>
        /// 檔案LogID
        /// </summary>
        [Key]
        public int FileLogId { get; set; }

        /// <summary>
        /// 路徑
        /// </summary>
        [StringLength(250)]
        public string ActionLink { get; set; }

        /// <summary>
        /// 檔案名稱
        /// </summary>
        [StringLength(100)]
        public string FileName { get; set; }

        /// <summary>
        /// 副檔名
        /// </summary>
        [StringLength(50)]
        public string Extension { get; set; }

        /// <summary>
        /// 事件
        /// </summary>
        [StringLength(50)]
        public string Event { get; set; }

        /// <summary>
        /// 記錄說明
        /// </summary>
        [StringLength(100)]
        public string Description { get; set; }

        /// <summary>
        /// 訊息
        /// </summary>
        [StringLength(2000)]
        public string Message { get; set; }

        /// <summary>
        /// 控制項
        /// </summary>
        [StringLength(50)]
        public string Controller { get; set; }

        /// <summary>
        /// Action
        /// </summary>
        [StringLength(50)]
        public string Action { get; set; }

        /// <summary>
        /// 記錄IP
        /// </summary>
        [StringLength(50)]
        public string ClientIP { get; set; }

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
