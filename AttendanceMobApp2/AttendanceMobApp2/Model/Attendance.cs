using System;
using System.Collections.Generic;
using System.Text;
using AttendanceMobApp2.Data;

namespace AttendanceMobApp2.Model
{
    public class Attendance : IEntity
    {
        public int Id { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public DateTime Date { get; set; }
        public Student Student { get; set; }
    }
}
