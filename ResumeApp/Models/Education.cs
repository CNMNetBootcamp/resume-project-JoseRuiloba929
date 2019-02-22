using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Models
{
    public class Education
    {
        [Key]
        public int educationID { get; set; }

        public int applicantID { get; set; }

        public string schoolName { get; set; }

        public string schoolCity { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "The State value is only two characters. ")]
        public string schoolState { get; set; }

        public int educationlevelId { get; set; }

        public string fieldofStudy { get; set; }

        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }

        //navigational properties
        public Submitter Submitter { get; set; }
    }
}
