using System;
using System.Collections.Generic;
using System.Text;
using AttendanceMobApp2.Data;

namespace AttendanceMobApp2.Model
{
    public class Student : IEntity
    {
        public int Id { get; set; }

        public string RegistrationString { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public static List<Student> Codes = new List<Student>();
    }
}
