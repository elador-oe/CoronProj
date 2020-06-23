using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovProj.Models
{
    public class Recovering
    {
        [Key]
        public int RecoveringId { get; set; }
        public int PeoplesId { get; set; }
        public ICollection<Peoples> recoverings { get; set; }
        public Peoples people {get; set;}
    }
}