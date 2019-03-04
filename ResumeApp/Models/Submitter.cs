using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Models
{
    public class Submitter
    {
        [Key]
        public int applicantID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "Middle Initial")]
        [StringLength(1, ErrorMessage = "The Middle Initial value cannot exceed 1 characters. ")]
        public string midInitial { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "City")]
        public string city { get; set; }

        [Required]
        [Display(Name = "State")]
        [StringLength(2, ErrorMessage = "The State value is only two characters. ")]
        public string state { get; set; }

        [Display(Name = "Phone")]
        public string submitterPhone { get; set; }

        [Display(Name = "Email")]
        public string submitterEmail { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return firstName + " " + midInitial + " " + lastName;
            }
        }

        //navigational properties
        public ICollection<Education> Educations { get; set; }
        public ICollection<SkillSet> SkillSets { get; set; }
        public ICollection<ProfSummary> ProfSummaries { get; set; }
        public ICollection<WorkExperience> WorkExperiences{ get; set; }
        public ICollection<Reference> References { get; set; }

    }
}
