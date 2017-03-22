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
            //Natures.Add(stuff.item.fields.nature);


            Lignes = new HashSet<Ligne>();
            Villes = new HashSet<Ville>();

            //Lignes = new Lignes();
            //Lignes.Add(item.fields.code_ligne);

            //Villes = new Villes();
            //Villes.Add();

            //Natures = new Nature();
            //Natures.Add();
            

        }

        [Key]
        [StringLength(10)]
        public string IdGare { get; set; }

        [StringLength(35)]
        public string nom { get; set; }

        [StringLength(25)]
        public string wgs84 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nature> Natures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ligne> Lignes { get; set; }
        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ville> Villes { get; set; }
    }
}
