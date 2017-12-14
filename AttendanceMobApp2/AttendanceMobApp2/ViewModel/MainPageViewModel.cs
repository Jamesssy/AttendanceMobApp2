using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AttendanceMobApp2.Data;
using AttendanceMobApp2.Model;
using AttendanceMobApp2.View;
using Xamarin.Forms;

namespace AttendanceMobApp2.ViewModel
{
    class MainPageViewModel : INotifyPropertyChanged
    {


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
            var date = Attendance.Attendances.Select(x => x.AttendanceDate.Date == DateTime.Now.Date).FirstOrDefault();

            if (date)
            {

                CheckedInImage = "ok4.jpg";
            }


        }

        public void CheckIfCheckedInString()
        {
            var date = Attendance.Attendances.Select(x => x.AttendanceDate.Date == DateTime.Now.Date).FirstOrDefault();

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

        public DateTime TodaysDate
        {
            get
            {
                return DateTime.Now;
            }
            
        }

        public void CheckLastCheckedIn()
        {
            var date = Attendance.Attendances.Select(x => x.AttendanceDate.Date).LastOrDefault();

            

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
