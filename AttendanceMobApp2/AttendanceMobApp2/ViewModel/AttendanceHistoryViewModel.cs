using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using AttendanceMobApp2.Model;

namespace AttendanceMobApp2.ViewModel
{
    public class AttendanceHistoryViewModel
    {
        public ObservableCollection<AttendanceHistoryTemp> HistoryOfAttendances { get; set; } =
            new ObservableCollection<AttendanceHistoryTemp>();



        public AttendanceHistoryViewModel(List<DateTime> attendancies)
        {
            //TODO: Relax.
            //var date = DateTime.Now.AddDays(-1);
            //Attendance attendance = new Attendance();
            //attendance.AttendanceDate = date;
            //attendance.ImageSource = "ok4.jpg";
            //HistoryOfAttendances.Add(attendance);

           
            //AttendanceHistoryTemp attendance = new AttendanceHistoryTemp();
            //attendance.AttendanceDate = date;
            //attendance.ImageSource = "ok4.jpg";
            //HistoryOfAttendances.Add(attendance);

            foreach (var item in attendancies)
            {
                AttendanceHistoryTemp attendance = new AttendanceHistoryTemp();
                attendance.AttendanceDate = item;
                attendance.ImageSource = "ok4.jpg";
                HistoryOfAttendances.Add(attendance);
                
                

            }
        }

        //private string imageSource = "ok4.jpg";

        //public string ImageSource
        //{
        //    get { return imageSource; }
        //    set
        //    {
        //        imageSource = value;
        //        OnPropertyChanged();
        //    }

        //}

        //for (int i = 0; i < 5; i++)
        //{
        //    Attendance attendance = new Attendance();
        //    attendance.AttendanceDate = date;
        //    attendance.ImageSource = "ok4.jpg";
        //    HistoryOfAttendances.Add(attendance);
        //    date = date.AddDays(1.0);


        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        //}

    }
}
       
    

