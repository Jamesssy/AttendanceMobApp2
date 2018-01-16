using System;
using System.Collections.Generic;
using System.Text;
using AttendanceMobApp2.Data;
using AttendanceMobApp2.Model;
using Xamarin.Forms;

namespace AttendanceMobApp2.ViewModel
{
    public class RegistrationPageViewModel
    {
        public string RegistrationCode { get; set; }

        public async void AddToRegistrationString()
        {
            //Student regCode = new Student();
            //regCode.RegistrationString = RegistrationCode;
            //Student.Codes.Add(regCode);
            Application.Current.Properties["regCode"] = RegistrationCode;
            await Application.Current.SavePropertiesAsync();
            //var repo = new RegistrationCodeRepository();
            //repo.Save(regCode);


        }
    }
}
