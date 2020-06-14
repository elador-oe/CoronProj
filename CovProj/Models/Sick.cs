﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovProj.Models
{
    public class Sick
    {
        [Key]
        public int SickId { get; set; }
        public int PeoplesId { get; set; }
        public int PlaceId { get; set; }
        public ICollection<Peoples> sickers { get; set; }
        public Peoples peoples { get; set; }
        public ICollection<InfecPlaces> visited { get; set; }
        public InfecPlaces places { get; set; }
    }
}