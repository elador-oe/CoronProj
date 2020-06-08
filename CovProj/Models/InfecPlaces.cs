using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovProj.Models
{
    public class InfecPlaces
    {
        public int PlaceID { get; set; }

        [Required(ErrorMessage = "City is requried")]
        [Display(Name = "Visited cities")]
        public string City { get; set; }
    }
}