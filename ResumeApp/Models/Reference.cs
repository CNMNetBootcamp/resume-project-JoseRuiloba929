using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Models
{
    public enum relationType
    { CoWorker, Supervisor, Friend,Family}
    public class Reference
    {
        [Key]
        public int referenceID { get; set; }

        public int applicantID { get; set; }

        [Display(Name = "Name")]
        public string referenceName { get; set; }

        [Display(Name = "Phone")]
        public string referencePhone { get; set; }

        [Display(Name = "Email")]
        public string referenceEmail { get; set; }

        [Display(Name = "Date Met")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime firstMet { get; set; }

        [Display(Name = "Relationship Type")]
        public relationType relationshipType { get; set; }

        [Display(Name = "Yrs Known")]
        public Single YKnown
        {
            get
            {
                return DateTime.Today.Year - firstMet.Year;
            }
        }

        //navigational properties
        public Submitter Submitter { get; set; }

    }
}
