using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovProj.Models
{
    public class Recovering
    {
        public int RecoveringID { get; set; }
        public ICollection<Peoples> recoverings { get; set; }
    }
}