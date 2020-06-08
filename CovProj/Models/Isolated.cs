using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovProj.Models
{
    public class Isolated
    {
        public int IsolatedID { get; set; }

        public string PlaceOfIsolation { get; set; }
        public ICollection<Peoples> isolated { get; set; }
    }
}