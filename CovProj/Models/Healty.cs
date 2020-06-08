using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovProj.Models
{
    public class Healty
    {
        public int HealthyID { get; set; }
        public ICollection<Peoples> healthyUsers { get; set; }
    }
}