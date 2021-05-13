namespace ShopCNweb.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }

        public decimal? PRICE { get; set; }

        public int? AMOUNT { get; set; }

        [Column(TypeName = "text")]
        public string DESCRIPTION { get; set; }

        [StringLength(50)]
        public string PHOTO { get; set; }

        public int? IDCATEGORY { get; set; }


        public virtual Category Category { get; set; }
    }
}
