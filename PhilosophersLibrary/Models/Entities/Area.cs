using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhilosophersLibrary.Models.Entities
{
    public class Area
    {
        public int AreaID { get; set; }
        [Display(Name = "Area")]
        public string Name { get; set; }

        public virtual ICollection<Philosopher> Philosophers { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}