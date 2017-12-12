using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceMobApp2.Model
{
    public class PersonRegistrationCode
    {
        public int Id { get; set; }

        public string RegistrationString { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public static List<PersonRegistrationCode> Codes = new List<PersonRegistrationCode>();
    }
}
