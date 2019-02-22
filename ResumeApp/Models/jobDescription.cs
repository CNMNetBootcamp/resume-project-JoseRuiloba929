using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Models
{
    public class JobDescription
    {
        [Key]
        public int jobDescriptionId { get; set; }

        [Required]
        public string jobExperience { get; set; }

        //navigational properties
        public WorkExperience WorkExperience { get; set; }
    }
}
