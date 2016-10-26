using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhilosophersLibrary.Models.Entities
{
    public class Nationality
    {
        public int NationalityID { get; set; }
        [Display(Name = "Nationality")]
        public string Name { get; set; }

        public virtual ICollection<Philosopher> Philosophers { get; set; }
    }
}