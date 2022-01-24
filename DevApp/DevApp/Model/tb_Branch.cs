namespace DevApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Branch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Branch()
        {
            tb_Device = new HashSet<tb_Device>();
        }

        [Key]
        public int branch_id { get; set; }

        [StringLength(3)]
        public string branch_no { get; set; }

        [StringLength(100)]
        public string branch_name { get; set; }

        [StringLength(200)]
        public string branch_addr { get; set; }

        [StringLength(15)]
        public string branch_tel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Device> tb_Device { get; set; }
    }
}
