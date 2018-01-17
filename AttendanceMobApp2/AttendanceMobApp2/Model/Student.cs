using System;
using System.Collections.Generic;
using System.Text;
using AttendanceMobApp2.Data;

namespace AttendanceMobApp2.Model
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string RegistrationCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Schoolclass SchoolClass { get; set; }
        public Attendance[] Attendances { get; set; }
    }
}
