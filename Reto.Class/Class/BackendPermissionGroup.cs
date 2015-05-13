using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reto.Class
{
    public class BackendPermissionGroup : BaseClass
    {
        /// <summary>
        /// 權限群組ID
        /// </summary>
        [Key]
        public int PermissionGroupId { get; set; }

        /// <summary>
        /// 群組
        /// </summary>
        public BackendGroup Group { get; set; }

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
