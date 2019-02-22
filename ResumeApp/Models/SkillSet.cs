using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Models
{
    public class SkillSet
    {
        [Key]
        public int skillsetID { get; set; }
        public int applicantID { get; set; }
        public int skillsetType { get; set; } //1-sotware 2-programing
        public string skillSetRecord { get; set; }

        //navigational properties
        public Submitter Submitter { get; set; }
    }
}
