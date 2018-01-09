using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AttendanceMobApp2.Data;
using AttendanceMobApp2.Model;
using AttendanceMobApp2.View;
using Plugin.Geolocator;
using Xamarin.Forms;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms.Xaml;

namespace AttendanceMobApp2.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {

        public async Task<Position> GetCurrentLocation()
        {
            Position position = null;
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;

                position = await locator.GetLastKnownLocationAsync();

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

                position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);

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
            return position;

        }
        

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
        public MainPageViewModel()
        {
            FirstName = "James";
            LastName = "Johansson";
            CheckIfCheckedInString();
            CheckIfCheckedInImage();
            CheckLastCheckedIn();
            
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
            get { return changeTextCommand ?? (changeTextCommand = new Command(() =>
            {
                LabelText = "Goodbye";
            })); }
            
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
            var repo = new AttendanceRepository();
            var date = repo.GetAll().Select(x => x.AttendanceDate.Date == DateTime.Now.Date).FirstOrDefault();
            if (date)
            {

                CheckedInImage = "ok4.jpg";
            }


        }

        public void CheckIfCheckedInString()
        {
            //var date = Attendance.Attendances.Select(x => x.AttendanceDate.Date == DateTime.Now.Date).FirstOrDefault();

            var repo = new AttendanceRepository();
            var date = repo.GetAll().Select(x => x.AttendanceDate.Date == DateTime.Now.Date).FirstOrDefault();

            if (date)
            {

                CheckedInString = "Du har checkat in idag!";
            }

            
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

            var repo = new AttendanceRepository();
            var date = repo.GetAll().Select(x => x.AttendanceDate.Date).LastOrDefault();

            LastCheckedIn = date;
            


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
