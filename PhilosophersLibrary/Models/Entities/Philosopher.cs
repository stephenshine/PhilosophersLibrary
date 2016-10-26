using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhilosophersLibrary.Models.Entities
{
    public class Philosopher
    {
        // <className>ID pattern causes property to be primary key
        public int PhilosopherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Date of death")]
        public DateTime DateOfDeath { get; set; }
        public Boolean IsAlive { get; set; }
        public string Description { get; set; }

        // Foreign keys have corresponding navigation properties
        // <NavigationProperty>ID naming convention cause EF to identify foreign keys
        public int NationalityID { get; set; }
        public int AreaID { get; set; }

        // Navigation properties - defined as virtual to use LazyLoading
        // Nationality and Area have a 1 to 1 relationship with philosopher
        // Books has a 1 to many relationship with philosopher
        public virtual Nationality Nationality { get; set; }
        public virtual Area Area { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}