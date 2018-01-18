using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AttendanceMobApp2.Data;
using AttendanceMobApp2.Model;
using AttendanceMobApp2.View;
using Newtonsoft.Json;
using Plugin.Geolocator;
using Xamarin.Forms;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms.Xaml;

namespace AttendanceMobApp2.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private static HttpClient client;
        private Student fetchedStudent;
        public List<DateTime> last10Attendances;
        public MainPageViewModel()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://kbryapiservice.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "9546482E-887A-4CAB-A403-AD9C326FFDA5");
            string regCode = Application.Current.Properties["regCode"] as string;
            var host = Dns.GetHostName();
            string ip = Dns.GetHostByName(host).AddressList[0].ToString();

            //fetchedStudent = GetStudentAsync(regCode).Result;
            fetchedStudent = GetStudentAsync("445566").Result;
            //last10Attendances = GetAttendenceDatesByAmountAsync(regCode, 10).Result;
            last10Attendances = GetAttendenceDatesByAmountAsync("445566", 10).Result;

            //FirstName = fetchedStudent.FirstName;
            //LastName = fetchedStudent.LastName;
            FirstName = fetchedStudent.FirstName;
            LastName = fetchedStudent.LastName ?? "Funkar inte";
            CheckIfCheckedInString();
            CheckIfCheckedInImage();
            CheckLastCheckedIn();
            CheckIfSignedIn();

        }

        public void CheckIfSignedIn()
        {
            var todaysDate = DateTime.Now.AddHours(1);
            CheckedInToday = true;
            if (last10Attendances.Count > 0)
            {
                
                if (last10Attendances.Any(x => x.Date == todaysDate.Date))
                {
                    checkedInString = "Du har checkat in idag!";
                    CheckedInImage = "ok4.jpg";
                    CheckedInToday = false;
                }


                LastCheckedIn = SortDescending(last10Attendances).FirstOrDefault();
            }


        }
        static List<DateTime> SortDescending(List<DateTime> list)
        {
            list.Sort((a, b) => b.CompareTo(a));
            return list;
        }


        private bool checkedInToday;

        public bool CheckedInToday
        {
            get { return checkedInToday; }
            set
            {
                checkedInToday = value;
                OnPropertyChanged();
            }
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

        public static async Task<List<DateTime>> GetAttendenceDatesByAmountAsync(string registrationCode, int amount)
        {
            try
            {
                string url = $"/api/GetAttendenceDatesByAmount/{registrationCode}/{amount}";
                var response = await client.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<List<DateTime>>(responseContent);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<Attendance> PostAttendanceAsync(Attendance attendance)
        {
            var serilizedAtten = JsonConvert.SerializeObject(attendance);

            Attendance attendanceResponse = null;
            var uri = $"/api/PostAttendance";
            var content = new StringContent(serilizedAtten, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(
                uri, content).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false); ;
                attendanceResponse = JsonConvert.DeserializeObject<Attendance>(responseString);
            }

            if (!response.IsSuccessStatusCode)
            {
                //TODO Notify that you are not close
            }

            return attendanceResponse;
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

        public async Task<Position> GetCurrentLocation()
        {
            Position position = null;
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;

                position = await locator.GetLastKnownLocationAsync().ConfigureAwait(false);

                //if (position != null)
                //{
                //    //got a cahched position, so let's use it.
                //    return position;
                //}

                if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                {
                    //not available or enabled
                    return position;
                }
                Position = position;
                var test = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true).ConfigureAwait(false);
                var test2 = test;

            }
            catch (Exception ex)
            {
                //Display error as we have timed out or can't get location.
            }

            if (position == null)
                return null;

            var output = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
                position.Timestamp, position.Latitude, position.Longitude,
                position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);
            Debug.WriteLine(output);
            CurrentPosition = $"Lat: {position.Latitude} - Long: {position.Longitude}";
            Position = position;
            return position;

        }


        public Position Position { get; set; }

        public Student Student => fetchedStudent;


        //private Position position;
        private string currentPosition;

        public string CurrentPosition
        {
            get { return currentPosition; }
            set
            {
                currentPosition = value;
                OnPropertyChanged();
            }
        }

        public bool IsLocationAvailable()
        {
            return CrossGeolocator.Current.IsGeolocationAvailable;
        }




        private string labelText = "Hello";







        public string LabelText
        {
            get { return labelText; }
            set
            {
                labelText = value;
                OnPropertyChanged();
            }
        }

        private Command changeTextCommand;

        public Command ChangeTextCommand
        {
            get
            {
                return changeTextCommand ?? (changeTextCommand = new Command(() =>
          {
              LabelText = "Goodbye";
          }));
            }

        }


        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        //public DateTime CheckedIn { get; set; }
        public string RegistrationCode { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }

        //public void PostAttendence()
        //{
        //    var attendance = new Attendance();
        //    attendance.Date = DateTime.Now;
        //    attendance.Student = fetchedStudent;
        //    var jsonObject = JsonConvert.SerializeObject(attendance);
        //    var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
        //    var result = client.PostAsync($"api/attendance", content).Result;
        //    result.EnsureSuccessStatusCode();
        //}
        //private static int ids = 0;

        //public void AddToAttendance()
        //{

        //    Attendance attendance = new Attendance();
        //    attendance.AttendanceDate = DateTime.Now;
        //    attendance.ImageSource = "ok4.jpg";
        //    //attendance.Id = ids++;
        //    Attendance.Attendances.Add(attendance);

        //    var repo = new AttendanceRepository();
        //    repo.Save(attendance);

        //}

        private string checkedInString = "Du har INTE checkat in idag!";

        public string CheckedInString
        {
            get { return checkedInString; }
            set
            {
                checkedInString = value;
                OnPropertyChanged();
            }
        }

        private string checkedInImage = "NotOk6.jpg";

        public string CheckedInImage
        {
            get { return checkedInImage; }
            set
            {
                checkedInImage = value;
                OnPropertyChanged();
            }
        }

        public void CheckIfCheckedInImage()
        {
            //var date = Attendance.Attendances.Select(x => x.AttendanceDate.Date == DateTime.Now.Date).FirstOrDefault();
            //var repo = new AttendanceRepository();
            //var date = repo.GetAll().Select(x => x.AttendanceDate.Date == DateTime.Now.Date).FirstOrDefault();
            //if (date)
            //{

            //    CheckedInImage = "ok4.jpg";
            //}


        }

        public void CheckIfCheckedInString()
        {



        }

        private DateTime lastCheckedIn;

        public DateTime LastCheckedIn
        {
            get { return lastCheckedIn; }
            set
            {
                lastCheckedIn = value;
                OnPropertyChanged();
            }
        }

        //private void GetLastCheckInFromFile()
        //{
        //    var repo = new AttendanceRepository();
        //    var date = repo.GetAll().LastOrDefault();
        //}

        public DateTime TodaysDate
        {
            get
            {
                return DateTime.Now;
            }

        }

        public void CheckLastCheckedIn()
        {
            //var date = Attendance.Attendances.Select(x => x.AttendanceDate.Date).LastOrDefault();
            //TODO: Add api call
            //var repo = new AttendanceRepository();
            //var date = repo.GetAll().Select(x => x.AttendanceDate.Date).LastOrDefault();

            //LastCheckedIn = date;



        }





        //private Command changeTextCheckInCommand;

        //public Command ChangeTextCheckInCommand
        //{
        //    get
        //    {
        //        return changeTextCheckInCommand ?? (changeTextCheckInCommand = new Command(() =>
        //        {
        //            CheckIfCheckedInString();
        //        }));
        //    }

        //}

    }
}
