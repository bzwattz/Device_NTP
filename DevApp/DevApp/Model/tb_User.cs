namespace DevApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_User()
        {
            tb_Destroy = new HashSet<tb_Destroy>();
            tb_Device = new HashSet<tb_Device>();
            tb_Service = new HashSet<tb_Service>();
        }

        [Key]
        public int User_id { get; set; }

        [StringLength(100)]
        public string Usr_name { get; set; }

        [StringLength(100)]
        public string Usr_lname { get; set; }

        [StringLength(50)]
        public string Login_name { get; set; }

        [StringLength(200)]
        public string Pswd { get; set; }

        [StringLength(80)]
        public string Position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Destroy> tb_Destroy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Device> tb_Device { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Service> tb_Service { get; set; }
    }
}
