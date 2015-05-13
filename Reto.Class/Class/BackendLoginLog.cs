using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reto.Class
{
    public class BackendLoginLog : BaseClass
    {
        /// <summary>
        /// 登入出記錄ID
        /// </summary>
        [Key]
        public string LoginLogId { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public LoginStatus Status { get; set; }

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
