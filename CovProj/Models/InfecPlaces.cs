using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovProj.Models
{
    public class InfecPlaces
    {
        [Key]
        public int PlaceId { get; set; }

        [Required(ErrorMessage = "City is requried")]
        [Display(Name = "Visited cities")]
        public string City { get; set; }
    }
}