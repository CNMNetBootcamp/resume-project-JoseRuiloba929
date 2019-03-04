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
        [Display(Name = "Employer")]
        public string employer { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime startDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime endDate { get; set; }

        [Required]
        [Display(Name = "City")]
        public string city { get; set; }

        [Required]
        [Display(Name = "State")]
        public string state { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string jobTitle { get; set; }
        public bool isStillEmployed { get; set; }

        //navigational properties
        public ICollection<JobDescription> jobDescriptions { get; set; }
        public Submitter Submitter { get; set; }

    }
}
