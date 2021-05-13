namespace ShopCNweb.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        [StringLength(50)]
        public string USERNAME { get; set; }

        [StringLength(50)]
        public string PASSWORD { get; set; }

        [StringLength(50)]
        public string FULLNAME { get; set; }
    }
}
