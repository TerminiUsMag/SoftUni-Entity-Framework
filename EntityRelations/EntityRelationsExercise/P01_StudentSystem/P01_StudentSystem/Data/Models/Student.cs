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
    public class Student
    {
        public Student()
        {
            Courses = new List<Course>();
            Homeworks = new List<Homework>();
        }
        [Key]
        [Column("StudentId")]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Unicode]
        public string Name { get; set; } = null!;
        [MaxLength(10), MinLength(10)]
        public string? PhoneNumber { get; set; }
        [Required]
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Homework> Homeworks { get; set; }

    }
    //    •	Student
    //o   StudentId
    //o   Name – up to 100 characters, unicode
    //o   PhoneNumber – exactly 10 characters, not unicode, not required
    //o RegisteredOn
    //o Birthday – not required

}
