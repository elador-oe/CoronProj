using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovProj.Models
{
    public class Sick
    {
        public int SickID { get; set; }
        public ICollection<Peoples> sickers { get; set; }
        public ICollection<InfecPlaces> visited { get; set; }
    }
}