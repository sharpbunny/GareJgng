namespace Gare
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ville")]
    public partial class Ville
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ville()
        {
            Gares = new HashSet<Gare>();
        }

        [Key]
        public int IdVille { get; set; }

        [StringLength(25)]
        public string nom { get; set; }

        public int? dept { get; set; }

        [StringLength(25)]
        public string CPVille { get; set; }

        public virtual CodePostal CodePostal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gare> Gares { get; set; }
    }
}
