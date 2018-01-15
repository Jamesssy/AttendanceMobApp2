using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AttendanceMobApp2.Model;
using Newtonsoft.Json;

namespace AttendanceMobApp2.Api
{
    class RegistrationApi
    {

        static HttpClient client = new HttpClient();
        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/%22");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "9546482E-887A-4CAB-A403-AD9C326FFDA5");
            Attendance newAttendance = new Attendance
            {
                AttendanceDate = DateTime.Now
            };

        }
        static async Task<Student> GetStudent(string registrationCode)
        {
            Student registrationStudent = null;
            HttpResponseMessage response = await client.GetAsync(registrationCode);
            if (response.IsSuccessStatusCode)
            {
                registrationStudent = JsonConvert.DeserializeObject<Student>(await response.Content.ReadAsStringAsync());
            }
            return registrationStudent;
        }

        static async Task<Attendance> PostAttendanceAsync(Attendance attendance)
        {
            
            var jsonObject = JsonConvert.SerializeObject(attendance);
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            var result = client.PostAsync($"api/attendance", content).Result;
            result.EnsureSuccessStatusCode();
            return attendance;
        }

    }
}
