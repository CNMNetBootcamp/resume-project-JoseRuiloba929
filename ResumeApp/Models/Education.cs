using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Models
{
    public enum degree
    { Diploma, Certificate, Associates, Bachelor, Masters, PHD }
    public class Education
    {
        [Key]
        public int educationID { get; set; }

        public int applicantID { get; set; }

        [Display(Name = "School")]
        public string schoolName { get; set; }

        [Display(Name = "City")]
        public string schoolCity { get; set; }

        [Required]
        [Display(Name = "State")]
        [StringLength(2, ErrorMessage = "The State value is only two characters. ")]
        public string schoolState { get; set; }

        [Display(Name = "Educational Level")]
        public degree educationlevelId { get; set; }

        [Display(Name = "Field of Study")]
        public string fieldofStudy { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime startdate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime enddate { get; set; }

        //navigational properties
        public Submitter Submitter { get; set; }
    }
}
