using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
            Resources = new HashSet<Resource>();
            Homeworks = new HashSet<Homework>();
        }
        [Key]
        [Column("CourseId")]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Unicode]
        public string Name { get; set; } = null!;
        [Unicode]
        public string? Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Price { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
    }
    //    •	Course
    //o   CourseId
    //o   Name – up to 80 characters, unicode
    //o   Description – unicode, not required
    //o StartDate
    //o EndDate
    //o Price

}
