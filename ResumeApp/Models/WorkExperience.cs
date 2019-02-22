using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Models
{
    public class WorkExperience
    {
        [Key]
        public int workID { get; set; }
        public int applicantID { get; set; }

        [Required]
        public string employer { get; set; }

        [Required]
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string state { get; set; }
        [Required]
        public string jobTitle { get; set; }
        public int jobDescriptionId { get; set; }
        public bool isStillEmployed { get; set; }

        //navigational properties
        public ICollection<JobDescription> jobDescriptions { get; set; }
        public Submitter Submitter { get; set; }

    }
}
