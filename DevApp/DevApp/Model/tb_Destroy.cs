namespace DevApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Destroy
    {
        [Key]
        public int Des_ID { get; set; }

        public int? Dev_id { get; set; }

        [StringLength(200)]
        public string Des_Reson { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Des_Date { get; set; }

        public int? User_id { get; set; }

        public virtual tb_Device tb_Device { get; set; }

        public virtual tb_User tb_User { get; set; }
    }
}
