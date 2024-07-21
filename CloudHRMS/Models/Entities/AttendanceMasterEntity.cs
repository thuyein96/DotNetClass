using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudHRMS.Models.Entities
{
    [Table("AttendanceMaster")]
    public class AttendanceMasterEntity:BaseEntity
	{
		public DateTime AttendanceDate { get; set; }

        public TimeSpan InTime { get; set; }

        public TimeSpan OutTime { get; set; }

        public bool IsLate { get; set; }

        public bool IsEarlyOut { get; set; }

        public bool IsLeave { get; set; }

        //set foreign key
        public string EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual EmployeeEntity Employee { get; set; }

        //set foreign key
        public string DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public virtual DepartmentEntity Department { get; set; }

        //set foreign key
        public string ShiftId { get; set; }
        [ForeignKey(nameof(ShiftId))]
        public virtual ShiftEntity Shift { get; set; }
    }
}

