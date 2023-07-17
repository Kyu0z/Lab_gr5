namespace Lab_gr5.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nhanvien")]
    public partial class Phongban
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phongban()
        {
            Phongbans = new HashSet<Phongban>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaPB { get; set; }

        [Required]
        [StringLength(50)]
        public string TenPB { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phongban> Phongbans { get; set; }
    }
}
