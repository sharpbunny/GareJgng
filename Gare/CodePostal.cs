namespace Gare
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CodePostal")]
    public partial class CodePostal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CPVille { get; set; }

        public int IdVille { get; set; }

        public virtual Ville Ville { get; set; }
    }
}
