using System;
using System.Collections.Generic;
using System.Text;
using AttendanceMobApp2.Model;

namespace AttendanceMobApp2.Data
{
    public class RegistrationCodeRepository : GenericFileRepository<Student>
    {
        public RegistrationCodeRepository() : base("RegCodeFile.json")
        {
            
        }
    }
}
