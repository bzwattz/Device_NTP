namespace DevApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Device
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Device()
        {
            tb_Destroy = new HashSet<tb_Destroy>();
            tb_Service = new HashSet<tb_Service>();
        }

        [Key]
        public int Dev_id { get; set; }

        [StringLength(100)]
        [Required]
        public string Dev_SN { get; set; }

        [StringLength(180)]
        [Required]
        public string Dev_Name { get; set; }

        [StringLength(100)]
        [Required]
        public string Dev_Model { get; set; }

        [StringLength(100)]
        [Required]
        public string Dev_Brand { get; set; }

        [StringLength(200)]
        [Required]
        public string Dev_Spec { get; set; }

        [Required]
        public decimal? Dev_Price { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Date_IN { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Warn_Start { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Warn_End { get; set; }

        [StringLength(255)]
        [Required]
        public string Dev_Note { get; set; }

        [StringLength(100)]
        [Required]
        public string Dev_NTP_Key { get; set; }

        public int? User_id { get; set; }

        public int? Dev_S_ID { get; set; }

        [StringLength(3)]
        public string Dep_id { get; set; }

        public int? branch_id { get; set; }

        public int? Type_id { get; set; }

        public int? ST_ID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Des_Date { get; set; }

        public virtual tb_Branch tb_Branch { get; set; }

        public virtual tb_Department tb_Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Destroy> tb_Destroy { get; set; }

        public virtual tb_Dev_Status tb_Dev_Status { get; set; }

        public virtual tb_Sub_Type tb_Sub_Type { get; set; }

        public virtual tb_Type tb_Type { get; set; }

        public virtual tb_User tb_User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Service> tb_Service { get; set; }
    }
}
