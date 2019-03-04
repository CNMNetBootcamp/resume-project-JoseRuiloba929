using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Models
{
    public enum skillCat
    { Software, Programming}
    public class SkillSet
    {
        [Key]
        public int skillsetID { get; set; }
        public int applicantID { get; set; }

        [Display(Name = "Skill Group")]
        public skillCat skillsetType { get; set; } //1-sotware 2-programing

        [Display(Name = "Skill Set")]
        public string skillSetRecord { get; set; }

        [Display(Name = "Sort Order")]
        public int sortOrder { get; set; }

        //navigational properties
        public Submitter Submitter { get; set; }
    }
}
