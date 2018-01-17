using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using AttendanceMobApp2.Model;
using Xamarin.Forms;

namespace AttendanceMobApp2.ViewModel
{
    public class AttendanceHistoryViewModel
    {
        public ObservableCollection<AttendanceListItem> HistoryOfAttendances { get; set; } = 
            new ObservableCollection<AttendanceListItem>();

        

        public AttendanceHistoryViewModel(List<DateTime> attendancies)
        {
            //TODO: Write real fucking code.
            //var date = DateTime.Now.AddDays(-1);
            //Attendance attendance = new Attendance();
            //attendance.AttendanceDate = date;
            //attendance.ImageSource = "ok4.jpg";
            //HistoryOfAttendances.Add(attendance);

            foreach (var item in attendancies)
            {
                HistoryOfAttendances.Add(new AttendanceListItem(){Date = item, ImageSource = "ok4.jpg" });

            }

            //for (int i = 0; i < 5; i++)
            //{
            //    Attendance attendance = new Attendance();
            //    attendance.AttendanceDate = date;
            //    attendance.ImageSource = "ok4.jpg";
            //    HistoryOfAttendances.Add(attendance);
            //    date = date.AddDays(1.0);


            //}


        }

       
    }

    public class AttendanceListItem
    {
        public ImageSource ImageSource { get; set; }
        public DateTime Date { get; set; }
    }
}
