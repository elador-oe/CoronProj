using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovProj.Models
{
    public class Healty
    {
        [Key]
        public int HealthyId { get; set; }
        public ICollection<Peoples> healthyUsers { get; set; }

        public Peoples peoples { get; set; }
    }
}