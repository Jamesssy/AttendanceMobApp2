using System;
using System.Collections.Generic;
using System.Text;
using AttendanceMobApp2.Data;
using AttendanceMobApp2.Model;

namespace AttendanceMobApp2.ViewModel
{
    public class RegistrationPageViewModel
    {
        public string RegistrationCode { get; set; }

        public void AddToRegistrationString()
        {
            PersonRegistrationCode regCode = new PersonRegistrationCode();
            regCode.RegistrationString = RegistrationCode;
            PersonRegistrationCode.Codes.Add(regCode);
            var repo = new RegistrationCodeRepository();
            repo.Save(regCode);


        }
    }
}
