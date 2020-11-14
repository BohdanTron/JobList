﻿using JobList.Domain.Common;
using System;
using System.Collections.Generic;

namespace JobList.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public Employee()
        {
            Invitations = new HashSet<Invitation>();
            Resumes = new HashSet<Resume>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public byte[] PhotoData { get; set; }
        public string PhotoMimeType { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int CityId { get; set; }
        
        public ICollection<Resume> Resumes { get; set; }
        public ICollection<Invitation> Invitations { get; set; }
    }
}
