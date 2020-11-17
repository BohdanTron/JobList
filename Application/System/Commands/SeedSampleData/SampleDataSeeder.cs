using Bogus;
using JobList.Application.Common.Interfaces;
using JobList.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JobList.Application.System.Commands.SeedSampleData
{
    public class SampleDataSeeder
    {
        private readonly IJobListDbContext _context;

        public SampleDataSeeder(IJobListDbContext context)
        {
            _context = context;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            await SeedRoles(cancellationToken);

            await SeedCitiesAsync(cancellationToken);

            await SeedSchoolsAsync(cancellationToken);

            await SeedWorkAreasAsync(cancellationToken);

            await SeedFacultiesAsync(cancellationToken);

            await SeedLanguagesAsync(cancellationToken);

            await SeedEmployeesAsync(cancellationToken);

            await SeedCompaniesAsync(cancellationToken);
        }

        private async Task SeedRoles(CancellationToken cancellationToken)
        {
            var roles = new Role[]
            {
                new Role { Name = "admin" },
                new Role { Name = "employee" },
                new Role { Name = "company" },
                new Role { Name = "recruiter" }
            };

            _context.Roles.AddRange(roles);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedCitiesAsync(CancellationToken cancellationToken)
        {
            var cities = new City[]
            {
                new City { Name = "New York"},
                new City { Name = "Jersey"},
                new City { Name = "Atlanta"},
                new City { Name = "Los Angeles"},
                new City { Name = "Boston"},
                new City { Name = "Philadelphia"},
                new City { Name = "Seattle"},
                new City { Name = "Washington DC"},
                new City { Name = "Las Vegas"},
                new City { Name = "Phoneix"},
                new City { Name = "San Francisco"},
                new City { Name = "Chicago"}
            };

            _context.Cities.AddRange(cities);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedSchoolsAsync(CancellationToken cancellationToken)
        {
            var schools = new School[]
            {
                new School { Name = "Chicago State University" },
                new School { Name = "Harvard University" },
                new School { Name = "Prinston University" },
                new School { Name = "Berklee College Of Arts" },
                new School { Name = "Stanford University" },
                new School { Name = "Massachusetts Institute of Technology"},
                new School { Name = "Columbia University" },
                new School { Name = "New York University" },
                new School { Name = "University of Arizona" },
                new School { Name = "Yale University" }
            };

            _context.Schools.AddRange(schools);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedWorkAreasAsync(CancellationToken cancellationToken)
        {
            var workAreas = new WorkArea[]
            {
                new WorkArea{ Name = "IT" },
                new WorkArea{ Name = "Sales" },
                new WorkArea{ Name = "Medicine" },
                new WorkArea{ Name = "Marketing and Advertising" },
                new WorkArea{ Name = "Law and Politics" },
                new WorkArea{ Name = "Science" },
                new WorkArea{ Name = "Tourism" },
                new WorkArea{ Name = "Arts" },
                new WorkArea{ Name = "Insurance" },
                new WorkArea{ Name = "Real Estate" },
                new WorkArea{ Name = "Finances" },
                new WorkArea{ Name = "Media" }
            };

            _context.WorkAreas.AddRange(workAreas);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedFacultiesAsync(CancellationToken cancellationToken)
        {
            var faculties = new Faculty[]
            {
                new Faculty{ Name = "Computer Science" },
                new Faculty{ Name = "Software Engineering"},
                new Faculty{ Name = "Applied Mathematics"},
                new Faculty{ Name = "Foreign Languages"},
                new Faculty{ Name = "International Relationships"},
                new Faculty{ Name = "Economics"},
                new Faculty{ Name = "Design"},
                new Faculty{ Name = "Faculty of Law"},
                new Faculty{ Name = "Marketing"},
                new Faculty{ Name = "Journalism"}
            };

            _context.Faculties.AddRange(faculties);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedLanguagesAsync(CancellationToken cancellationToken)
        {
            var languages = new Language[]
            {
                new Language { Name = "English" },
                new Language { Name = "Ukrainian" },
                new Language { Name = "Russian" },
                new Language { Name = "Polish" },
                new Language { Name = "Greek" },
                new Language { Name = "Japanese" },
                new Language { Name = "Spanish" },
                new Language { Name = "Chinese" },
                new Language { Name = "German" },
                new Language { Name = "Roman" }
            };

            _context.Languages.AddRange(languages);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedEmployeesAsync(CancellationToken cancellationToken)
        {
            // Seed resumes with linked entities
            var resume = new Resume
            {
                WorkAreaId = _context.WorkAreas.First(x => x.Name == "IT").Id,
                Courses = "Certification training",
                KeySkills = "Hardworking, persuasive",
                SoftSkills = "Plastic surgery",
                Facebook = "www.facebook.com",
                FamilyState = "Not Married",
                Introduction = "Persuasive person with strong desire to work",
                Linkedin = @"https://www.linkedin.com/",
                Instagram = @"https://www.instagram.com/",
                Skype = @"https://www.skype.com/",
                Github = @"https://www.github.com/",
                Position = "Developer"
            };

            resume.ResumeLanguages.Add(new ResumeLanguage { LanguageId = 1 });
            resume.EducationPeriods.Add(new EducationPeriod { SchoolId = 1, FacultyId = 1, StartDate = new DateTime(2002, 12, 3), FinishDate = new DateTime(2005, 6, 14) });
            resume.Experiences.Add(new Experience { CompanyName = "Epam", Position = "Trainee", StartDate = new DateTime(2008, 12, 25), FinishDate = new DateTime(2016, 9, 5) });

            // Seed employee
            var employee = new Employee 
            { 
                FirstName = "Bohdan", 
                LastName = "Tron", 
                Phone = "0502758765", 
                Sex = "male", 
                BirthDate = new DateTime(1995, 8, 3), 
                Email = "employee@gmail.com", 
                Password = "password",
                RoleId = _context.Roles.First(x => x.Name == "admin").Id, 
                CityId = 1
            };

            employee.Resumes.Add(resume);

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedCompaniesAsync(CancellationToken cancellationToken)
        {
            // Seed recruiter with linked entities
            var recruiter = new Recruiter
            {
                FirstName = "Kate",
                LastName = "Janner",
                Phone = "0934561223",
                Email = "recruiter@gmail.com",
                Password = "password",
                RoleId = _context.Roles.First(x => x.Name == "recruiter").Id
            };

            recruiter.Vacancies.Add(new Vacancy
            {
                Name = ".Net Developer",
                Description = "Client: is a European company, one of the industry leaders in transport and traffic solutions. It develops innovative systems for parking automation, traffic lights navigation, public transport management and data streams for autonomous vehicles." +
                "If you want to take part in developing solutions which power the transport of the future — it’s a good project for you.",
                Requirements = "Minimal 3 year experience in .NET web/API development (preferably .NET core). " +
                "Good knowledge of SQL(MySQL / PostgreSQL). " +
                "Being capable to do some front-end tasks. ",
                BePlus = "Experience with Angular JS. " +
               "Experience in setting up CI / CD. " +
               "English: intermediate or higher.",
                IsChecked = true,
                Offering = "Working in friendly successful team. Ability to grow in professional area.",
                Salary = 5000,
                FullPartTime = "Part-time",
                CityId = 5,
                WorkAreaId = _context.WorkAreas.First(x => x.Name == "IT").Id
            });

            // Seed company
            var company = new Company
            {
                Name = "SoftServe",
                BossName = "Taras Kytsmey",
                FullDescription = "At SoftServe, we strive to make the world a better place. Our Corporate Social Responsibility program ensures a sustainable future for our associates, our company, and the communities in which we live and work across the globe. The key to fulfilling this mission is our responsibility towards customers, associates, and society. We are committed to addressing various economic, social, and environmental issues.",
                ShortDescription = "Build you career here",
                Address = "2D Sadova Street Lviv",
                Phone = "0322409090",
                Site = @"https://softserveinc.com/en-us/",
                Email = "softservecompany@gmail.com",
                RoleId = 3,
                Password = "password"
            };

            company.Recruiters.Add(recruiter);

            _context.Companies.Add(company);

            var companyFaker = new Faker<Company>()
                .RuleFor(o => o.Name, f => f.Company.CompanyName())
                .RuleFor(o => o.BossName, f => f.Name.FirstName())
                .RuleFor(o => o.FullDescription, f => f.Lorem.Sentence(3))
                .RuleFor(o => o.ShortDescription, f => f.Lorem.Slug(1))
                .RuleFor(o => o.Address, f => f.Address.FullAddress())
                .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(o => o.Site, f => f.Internet.Url())
                .RuleFor(o => o.Email, f => f.Internet.Email())
                .RuleFor(o => o.Password, f => f.Internet.Password())
                .RuleFor(o => o.RoleId, _context.Roles.First(x => x.Name == "company").Id);

            var companies = companyFaker.Generate(25);

            _context.Companies.AddRange(companies);

            await _context.SaveChangesAsync(cancellationToken);

            var recruiterFaker = new Faker<Recruiter>()
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(o => o.Email, f => f.Internet.Email())
                .RuleFor(o => o.Password, f => f.Internet.Password())
                .RuleFor(o => o.CompanyId, f => f.PickRandom(companies).Id)
                .RuleFor(o => o.RoleId, f => _context.Roles.First(x => x.Name == "company").Id);

            var recruiters = recruiterFaker.Generate(20);

            _context.Recruiters.AddRange(recruiters);

            await _context.SaveChangesAsync(cancellationToken);

            var vacancyFaker = new Faker<Vacancy>()
                .RuleFor(o => o.Name, f => f.Name.JobTitle())
                .RuleFor(o => o.Description, f => f.Name.JobDescriptor())
                .RuleFor(o => o.Requirements, f => f.Lorem.Sentence())
                .RuleFor(o => o.Offering, f => f.Lorem.Sentence())
                .RuleFor(o => o.BePlus, f => f.Lorem.Sentence())
                .RuleFor(o => o.IsChecked, f => f.PickRandom(true, false))
                .RuleFor(o => o.Salary, f => f.PickRandom(1000))
                .RuleFor(o => o.FullPartTime, f => f.PickRandom("Full-time", "Part-time"))
                .RuleFor(o => o.RecruiterId, f => f.PickRandom(recruiters).Id)
                .RuleFor(o => o.CityId, f => f.PickRandom(_context.Cities.Select(x => x.Id)).First())
                .RuleFor(o => o.WorkAreaId, f => f.PickRandom(_context.WorkAreas.Select(x => x.Id)).First());

            var vacancies = vacancyFaker.Generate(15);

            _context.Vacancies.AddRange(vacancies);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
