using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Models
{
    public class Reference
    {
        [Key]
        public int referenceID { get; set; }

        public int applicantID { get; set; }
        public string referenceName { get; set; }
        public string referencePhone { get; set; }

        public string referenceEmail { get; set; }

        public DateTime firstMet { get; set; }

        public int relationshipType { get; set; }
        public int yrsKnown { get; set; }

        //navigational properties
        public Submitter Submitter { get; set; }

    }
}
