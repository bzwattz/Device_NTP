namespace DevApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Serv_ID { get; set; }

        public int? Dev_id { get; set; }

        [StringLength(200)]
        public string Serv_Reson { get; set; }

        [StringLength(200)]
        public string Serv_Solve { get; set; }

        public decimal? Serv_Price { get; set; }

        public DateTime? Date_Work { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Date_Finish { get; set; }

        public int? Serv_Status_id { get; set; }

        public int? User_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Date_Modify { get; set; }

        [StringLength(100)]
        public string Serv_Store { get; set; }

        [StringLength(200)]
        public string Serv_Note { get; set; }

        public virtual tb_Device tb_Device { get; set; }

        public virtual tb_Service_Status tb_Service_Status { get; set; }

        public virtual tb_User tb_User { get; set; }
    }
}
