﻿using JobList.Domain.Common;
using System.Collections.Generic;

namespace JobList.Domain.Entities
{
    public class Company : AuditableEntity
    {
        public Company()
        {
            Recruiters = new HashSet<Recruiter>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string BossName { get; set; }
        public string FullDescription { get; set; }
        public string ShortDescription { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public byte[] LogoData { get; set; }
        public string LogoMimetype { get; set; }
        public string Site { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public ICollection<Recruiter> Recruiters { get; set; }
    }
}
