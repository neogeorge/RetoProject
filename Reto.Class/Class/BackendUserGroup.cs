using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reto.Class
{
    public class BackendUserGroup : BaseClass
    {
        /// <summary>
        /// 會員群組ID
        /// </summary>
        [Key]
        public int UserGroupId { get; set; }

        /// <summary>
        /// 會員
        /// </summary>
        public BackendUser User { get; set; }

        /// <summary>
        /// 群組
        /// </summary>
        public BackendGroup Group { get; set; }

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
