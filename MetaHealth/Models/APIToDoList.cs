namespace MetaHealth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("APIToDoList")]
    public partial class APIToDoList
    {
        [Key]
        public int PK { get; set; }

        public int UserNum { get; set; }

        [Required]
        [StringLength(256)]
        public string CalandarID { get; set; }

        [Required]
        [StringLength(256)]
        public string EventID { get; set; }

        public bool Checked { get; set; }

        public virtual HelpAlongUser HelpAlongUser { get; set; }
    }
}
