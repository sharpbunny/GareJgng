namespace Gare
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gare")]
    public partial class Gare
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gare()
        {
            Natures = new HashSet<Nature>();
            Lignes = new HashSet<Ligne>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdGare { get; set; }

        [Required]
        [StringLength(60)]
        public string nom { get; set; }

        [Required]
        [StringLength(25)]
        public string wgs84 { get; set; }

        public int IdVille { get; set; }

        public virtual Ville Ville { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nature> Natures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ligne> Lignes { get; set; }
    }
}
