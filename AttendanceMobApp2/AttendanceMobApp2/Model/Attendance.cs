using System;
using System.Collections.Generic;
using System.Text;
using AttendanceMobApp2.Data;

namespace AttendanceMobApp2.Model
{
    public class Attendance : IEntity
    {
        public int Id { get; set; }

        public DateTime AttendanceDate { get; set; }

        public string ImageSource { get; set; }

        public static List<Attendance> Attendances = new List<Attendance>();
    }
}
