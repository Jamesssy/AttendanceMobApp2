using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using AttendanceMobApp2.Model;

namespace AttendanceMobApp2.ViewModel
{
    public class AttendanceHistoryViewModel
    {
        public ObservableCollection<Attendance> HistoryOfAttendances { get; set; } = 
            new ObservableCollection<Attendance>();


        public AttendanceHistoryViewModel()
        {
            var date = DateTime.Now;

            for (int i = 0; i < 5; i++)
            {
                Attendance attendance = new Attendance();
                attendance.AttendanceDate = date;
                attendance.ImageSource = "ok4.jpg";
                HistoryOfAttendances.Add(attendance);
                date = date.AddDays(1.0);


            }

           
        }

    }
}
