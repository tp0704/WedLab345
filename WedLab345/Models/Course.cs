using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WedLab345.Models
{
    public class Course
    {
        public int Id { get; set; }
        public ApplicationUser lecturer { get; set; }
        [Required]
        public string lecturerId { get; set; }
        [Required]
        [StringLength(255)]
        public string place { get; set; }
        public DateTime DateTime { get; set; }
        public Category Category { get; set; }
        [Required]
        public byte CategoryId { get; set; }
    }
}