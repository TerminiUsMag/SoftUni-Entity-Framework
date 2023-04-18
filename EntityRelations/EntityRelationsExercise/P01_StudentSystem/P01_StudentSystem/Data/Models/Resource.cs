using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        [Column("ResourceId")]
        public int Id { get; set; }
        [Required]
        [Unicode]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        public string Url { get; set; } = null!;
        public ResourceType ResourceType { get; set; }
        [Required]
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
    //•	Resource
    //o   ResourceId
    //o   Name – up to 50 characters, unicode
    //o   Url – not unicode
    //o ResourceType – enum, can be Video, Presentation, Document or Other
    //o   CourseId

}
