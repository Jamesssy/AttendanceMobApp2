using System;
using System.Collections.Generic;
using System.Text;
using AttendanceMobApp2.Model;

namespace AttendanceMobApp2.Data
{
    public class AttendanceRepository : GenericFileRepository<Attendance>
    {
        public AttendanceRepository() : base("AttendanceFile.json")
        {
            
        }
    }
}
