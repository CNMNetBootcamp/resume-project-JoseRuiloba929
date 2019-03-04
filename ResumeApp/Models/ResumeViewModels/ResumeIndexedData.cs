using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Models.ResumeViewModels
{
    public class ResumeIndexedData
    {
        public IEnumerable<Submitter> Submitter { get; set; }
        public IEnumerable<Education> Educations { get; set; }
        public IEnumerable<JobDescription> JobDescriptions { get; set; }
        public IEnumerable<ProfSummary> profSummaries { get; set; }

        public IEnumerable<Reference> References { get; set; }
        public IEnumerable<SkillSet> SkillSets { get; set; }
        public IEnumerable<WorkExperience> WorkExperiences { get; set; }


    }
}
