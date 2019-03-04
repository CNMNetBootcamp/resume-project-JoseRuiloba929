using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Models.ResumeViewModels
{
    public class WorkExpJobDetail
    {
        public IEnumerable<Submitter> Submitter { get; set; }
        public IEnumerable<WorkExperience> WorkExperiences { get; set; }
        public IEnumerable<JobDescription> JobDescriptions { get; set; }
    }
}
