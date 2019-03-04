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

        public int workID { get; set; }

        [Required]
        [Display(Name = "Experience")]
        public string jobExperience { get; set; }

        [Display(Name = "Sort Order")]
        public int sortOrder { get; set; }

        //navigational properties
        public WorkExperience WorkExperience { get; set; }
    }
}
