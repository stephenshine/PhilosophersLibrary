using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhilosophersLibrary.Models.Entities
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        [Display(Name = "Philosopher")]
        public int PhilosopherID { get; set; }
        [Display(Name = "Area")]
        public int AreaID { get; set; }

        public virtual Philosopher Philosopher { get; set; }
        public virtual Area Area { get; set; }
    }
}