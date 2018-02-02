using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DojoLeague.Models

{
    public class Dojo : BaseEntity {

        [Key]
        public int dojo_id { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "Dojo name must be at least 2 characters long")]
        [Display(Name = "Dojo Name:")]
        public string DojoName {get; set;}

        [Required]
        [MinLength(2, ErrorMessage = "Dojo location must be at least 2 characters long")]
        [Display(Name = "Dojo Location:")]
        public string DojoLocation {get; set;}

        [Required]
        [Display(Name = "Additional Dojo Information:")]
        public string DojoInfo {get; set;}

        public ICollection<Ninja> ninjas { get; set; }
    }
}