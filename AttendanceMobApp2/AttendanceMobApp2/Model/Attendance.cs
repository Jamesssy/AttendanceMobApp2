using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceMobApp2.Model
{
    public class Attendance
    {
        public int Id { get; set; }

        public DateTime AttendanceDate { get; set; }

        public string ImageSource { get; set; }

        public static List<Attendance> Attendances = new List<Attendance>();
    }
}
