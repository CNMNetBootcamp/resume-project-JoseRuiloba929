using ResumeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(JobContext context)
        {
            //context.Database.EnsureCreated();

            // look for submitter
            if (context.Submitter.Any())
            {
                return;
            }
            var submitter = new Submitter[]
            {
                new Submitter {firstName="Jose", midInitial="P", lastName="Ruiloba", city="Albuquerque",state="NM",submitterEmail="Jose_ruiloba@outloo.com",  submitterPhone="5054400649"}
            };
            foreach (Submitter s in submitter)
            {
                context.Submitter.Add(s);
            }
            context.SaveChanges();

            //look for Prof Summary
            if (context.ProfSummary.Any())
            {
                return;
            }
            var profSummary = new ProfSummary[]
                {
                    new ProfSummary{applicantID=1, ProfSum="3+ years of experience in managing application development projects and utilizing Agile Methodology with Rally. ", sortOrder=1},
                    new ProfSummary{applicantID=1, ProfSum="7+ years of experience with project scheduling for Facilities Construction and Manufacturing utilizing Primavera software (P3 DOS to P6 R15) and MS Project. ", sortOrder=2},
                    new ProfSummary{applicantID=1, ProfSum="Possesses a strong technical, analytical, and problem-solving aptitude.", sortOrder=3},
                    new ProfSummary{applicantID=1, ProfSum="Knowledge of database and interface structures with the ability to serve as a liaison between customer and programmer.", sortOrder=4},
                    new ProfSummary{applicantID=1, ProfSum="Experienced in developing MS Excel and Access based applications. ", sortOrder=5},
                     new ProfSummary{applicantID=1, ProfSum="Over 2+ yrs SharePoint (2007/2010/2016 Office 365)", sortOrder=6},
                };
            foreach (ProfSummary s in profSummary)
            {
                context.ProfSummary.Add(s);
            }
            context.SaveChanges();

            // look for skillset
            if (context.SkillSets.Any())
            {
                return;
            }
            var skillSet = new SkillSet[]
            {
                new SkillSet {applicantID=1, skillsetType=skillCat.Software,skillSetRecord="PRIMAVERA (P3 to P6 R15), MS Project, MS SharePoint 2007/2010, Business Objects (BOXI),", sortOrder=1},
                new SkillSet {applicantID=1, skillsetType=skillCat.Software,skillSetRecord="Web Works, Microsoft Office tools namely Access, Excel, Outlook, PowerPoint and Word, ", sortOrder=2},
                new SkillSet {applicantID=1, skillsetType=skillCat.Software,skillSetRecord="SharePoint Designer, InfoPath, SharePoint REST API and Workflows ", sortOrder=3},
                new SkillSet {applicantID=1, skillsetType=skillCat.Programming,skillSetRecord="HTML, limited JavaScript experience, VBA for Excel and Access, sharpoint workflows using REST, ", sortOrder=4},
                new SkillSet {applicantID=1, skillsetType=skillCat.Programming,skillSetRecord="SharePoint Workflows generation is Designer, SQL (table\view creation, stored proc development)", sortOrder=5}
            };
            foreach (SkillSet s in skillSet)
            {
                context.SkillSets.Add(s);
            }
            context.SaveChanges();

            //look for WorkExperience
            if (context.WorkExperiences.Any())
            {
                return;
            }
            var wkExperience = new WorkExperience[]
            {
                new WorkExperience { applicantID=1, employer="Intel", city="Rio Rancho", state="NM", jobTitle="NM Systems Analyst", startDate=DateTime.Parse("2001-03-15"), endDate=DateTime.Parse("2003-03-15"), isStillEmployed=false},
                new WorkExperience { applicantID=1, employer="Intel", city="Rio Rancho", state="NM", jobTitle="VF Central Schedule Systems", startDate=DateTime.Parse("2003-03-16"), endDate=DateTime.Parse("2008-03-15"), isStillEmployed=false},
                new WorkExperience { applicantID=1, employer="Intel", city="Rio Rancho", state="NM", jobTitle="Customer Business Analyst", startDate=DateTime.Parse("2008-03-16"), endDate=DateTime.Parse("2016-03-15"), isStillEmployed=false},
                new WorkExperience { applicantID=1, employer="Sabio Systems at CNM", city="Albuquerque", state="NM", jobTitle="SharePoint Developer", startDate=DateTime.Parse("2016-09-29"), endDate=DateTime.Parse("2017-06-30"), isStillEmployed=false},
                new WorkExperience { applicantID=1, employer="Netpolarity at The GAP", city="Albuquerque", state="NM", jobTitle="Business Solutions Developer", startDate=DateTime.Parse("2017-07-01"), endDate=DateTime.Parse("2017-08-29"), isStillEmployed=false},
                new WorkExperience { applicantID=1, employer="Employers Pro Advantage at SolAero Technologies", city="Albuquerque", state="NM", jobTitle="SharePoint Developer", startDate=DateTime.Parse("2017-09-29"), endDate=DateTime.Parse("2017-10-20"), isStillEmployed=false}
            };
            foreach (WorkExperience s in wkExperience)
            {
                context.WorkExperiences.Add(s);
            }
            context.SaveChanges();

            //look for jobdescriptions
            if (context.JobDescriptions.Any())
            {
                return;
            }
            var jobdescription = new JobDescription[]
            {
                new JobDescription { workID=1, sortOrder=1, jobExperience="Provided site-based system IT support for the implementation of the P3e and web based integration solution VF Schedule. "},
                new JobDescription { workID=1, sortOrder=2, jobExperience="Performed manufacturing project scheduling support, which included and was not limited to schedule activity development, progress update, critical path analysis, what-if analysis, risk analysis and project summary reporting."},
                new JobDescription { workID=2, sortOrder=1, jobExperience="Provided Global Technical support for Asia, Ireland, Israel and Americas sites as the Primavera/ VF Schedule Lead and Customer Business Analyst."},
                new JobDescription { workID=2, sortOrder=2, jobExperience="This included working with IT and upstream/downstream systems, training and documentation development."},
                new JobDescription { workID=2, sortOrder=3, jobExperience="Conducted and lead P3e System Core Team and facilitated the system user group meetings to cover VF Schedule/ P3e use and issues/enhancements."},
                new JobDescription { workID=3, sortOrder=1, jobExperience="Managed various applications: BoS (Bill of Quantity System), CS ETS (Estimating Tracking System), PIT (Project Information Tool) and BOXI application"},
                new JobDescription { workID=3, sortOrder=2, jobExperience="Supported VersaPro (Oracle Cost Tracking Application); Testing and technical support for various Excel and Access application job aides. "},
                new JobDescription { workID=3, sortOrder=3, jobExperience="Developed, managed and maintained various SharePoint applications and sites, Data Repository and Web sites. "},
                new JobDescription { workID=4, sortOrder=1, jobExperience="Work with different departments to provide SharePoint solutions utilizing InfoPath, SharePoint designer and REST API calls/ SharePoint workflow"},
                new JobDescription { workID=4, sortOrder=2, jobExperience="Developed various solutions to help automate processes and increase efficiency."},
                new JobDescription { workID=4, sortOrder=3, jobExperience="Provided project management support to ensure project solutions meet customer’s needs."},
                new JobDescription { workID=4, sortOrder=4, jobExperience="Worked to develop dashboards and KPI indicators using PowerBI to help support decision making."},
                new JobDescription { workID=5, sortOrder=1, jobExperience="Developed VBA solutions with MS Access and Excel for different departments."},
                new JobDescription { workID=6, sortOrder=1, jobExperience="Developed SharePoint Owner and User Training. Designed and built Department and team sites"},
                new JobDescription { workID=6, sortOrder=2, jobExperience="Worked to provide solutions utilizing InfoPath and SharePoint designer to different customers in the organization."},
                new JobDescription { workID=6, sortOrder=3, jobExperience="Provided various solution scenarios for extranet design to support companies business needs"},
            };
            foreach (JobDescription s in jobdescription)
            {
                context.JobDescriptions.Add(s);
            }
            context.SaveChanges();

            //look for educations
            if (context.Educations.Any())
            {
                return;
            }
            var education = new Education[]
            {
                new Education { applicantID=1, schoolName="Rio Grande High School",schoolCity="Albuquerque", schoolState="NM", educationlevelId=degree.Diploma, startdate=DateTime.Parse("1979-08-15"), enddate=DateTime.Parse("1983-5-15")},
                new Education { applicantID=1, schoolName="New Mexico State University", schoolCity="Las Cruces", schoolState="NM", educationlevelId=degree.Bachelor,  fieldofStudy="Electrical Engineering" ,startdate=DateTime.Parse("1983-08-15") , enddate=DateTime.Parse("1989-5-15")}
            };
            foreach (Education s in education)
            {
                context.Educations.Add(s);
            }
            context.SaveChanges();


            //look for reference
            if (context.References.Any())
            {
                return;
            }
            var reference = new Reference[]
            {
                new Reference {applicantID=1, referenceName="Ian van Oene", referenceEmail="", referencePhone="5059179736", relationshipType=relationType.CoWorker, firstMet=DateTime.Parse("1992-08-01")},
                new Reference {applicantID=1, referenceName="Brian Jacobs", referenceEmail="brian_jacobs@yahoo.com", referencePhone="5055066131", relationshipType=relationType.CoWorker, firstMet=DateTime.Parse("2007-03-01")},
                new Reference {applicantID=1, referenceName="Juan Gonzales", referenceEmail="juangonzales@gmail.com", referencePhone="5056047185", relationshipType=relationType.CoWorker, firstMet=DateTime.Parse("2004-06-01")},
                new Reference {applicantID=1, referenceName="Erica Burks", referenceEmail="ekburks@msn.com", referencePhone="5052392648", relationshipType=relationType.CoWorker,firstMet=DateTime.Parse("2001-03-01")},
                new Reference {applicantID=1, referenceName="Tom Hensley", referenceEmail="thensley@yahoo.com", referencePhone="5059173697", relationshipType=relationType.CoWorker,firstMet=DateTime.Parse("2017-09-29")}

            };
            foreach (Reference s in reference)
            {
                context.References.Add(s);
            }
            context.SaveChanges();

        }
    }
}
