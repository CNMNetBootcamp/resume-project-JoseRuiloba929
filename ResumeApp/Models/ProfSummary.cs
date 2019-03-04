using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Models
{
    public class ProfSummary
    {
        [Key]
        public int profSummaryID { get; set; }
        public int applicantID { get; set; }

        [Display(Name = "Sort Order")]
        public int sortOrder { get; set; }
        
        [Display(Name ="Professional Summary")]
        public string ProfSum { get; set; }

        //navigational properties
        public Submitter Submitter { get; set; }
    }
}
