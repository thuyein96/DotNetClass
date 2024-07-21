using CloudHRMS.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudHRMS.Models.ViewModels
{
    public class AttendanceMasterViewModel
    {
        public string Id { get; set; }
        public DateTime AttendanceDate { get; set; }

        public TimeSpan InTime { get; set; }

        public TimeSpan OutTime { get; set; }

        public bool IsLate { get; set; }

        public bool IsEarlyOut { get; set; }

        public bool IsLeave { get; set; }

        //set foreign key
        public string EmployeeId { get; set; }

        //set foreign key
        public string DepartmentId { get; set; }

        //set foreign key
        public string ShiftId { get; set; }
    }
}
