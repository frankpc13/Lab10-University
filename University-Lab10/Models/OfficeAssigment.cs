using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_Lab10.Models
{
    public class OfficeAssigment
    {
        [Key]
        [ForeignKey("Instructor")]

        public int InstructorID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        public bool isActive { get; set; } = true;

        public virtual Instructor Instructor { get; set; }
    }
}