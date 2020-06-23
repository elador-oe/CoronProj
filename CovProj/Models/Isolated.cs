using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovProj.Models
{
    public class Isolated
    {
        [Key]
        public int IsolatedId { get; set; }

        [DataType(DataType.Text)]
        public string PlaceOfIsolation { get; set; }
        public ICollection<Peoples> isolated { get; set; }

        public Peoples peoples { get; set; }
    }
}