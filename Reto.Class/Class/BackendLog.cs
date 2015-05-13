using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reto.Class
{
    public class BackendLog : BaseClass
    {
        /// <summary>
        /// LogID
        /// </summary>
        //[Key]
        public int LogId { get; set; }

        /// <summary>
        /// 路徑
        /// </summary>
        [StringLength(250)]
        public string ActionLink { get; set; }

        /// <summary>
        /// 呼叫的Function名稱
        /// </summary>
        [StringLength(50)]
        public string FunctionName { get; set; }

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
        /// 參數
        /// </summary>
        [StringLength(2000)]
        public string Paramer { get; set; }

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
        /// 狀態
        /// </summary>
        public LogStatus Status { get; set; }

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
