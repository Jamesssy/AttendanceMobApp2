using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceMobApp2.Model
{
    public class AttendanceHistoryTemp
    {
        public int Id { get; set; }

        public DateTime AttendanceDate { get; set; }

        public string ImageSource { get; set; }

        public virtual Attendance Attendance { get; set; }


    }
}
