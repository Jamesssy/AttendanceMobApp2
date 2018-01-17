using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AttendanceMobApp2.Model;
using Newtonsoft.Json;

namespace AttendanceMobApp2.Service
{
    class ApiService
    {
        private static HttpClient client;
        public ApiService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://10.0.2.2:59171");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "9546482E-887A-4CAB-A403-AD9C326FFDA5");
        }



        public static async Task<Student> GetStudentAsync(string registrationCode)
        {
            try
            {
                string url = $"/api/GetStudentInfo/{registrationCode}";
                var response = await client.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<Student>(responseContent);
            }
            catch (Exception e)
            {
                return null;
            }

        }









        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
