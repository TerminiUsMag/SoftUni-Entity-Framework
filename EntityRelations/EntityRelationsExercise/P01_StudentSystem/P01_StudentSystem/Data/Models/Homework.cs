﻿using P01_StudentSystem.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        [Column("HomeworkId")]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; } = null!;
        [Required]
        public ContentType ContentType { get; set; }
        [Required]
        public DateTime SubmissionTime { get; set; }
        [Required]
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
    //    •	Homework
    //o   HomeworkId
    //o   Content – string, linking to a file, not unicode
    //o   ContentType - enum, can be Application, Pdf or Zip
    //o   SubmissionTime
    //o   StudentId
    //o   CourseId

}
