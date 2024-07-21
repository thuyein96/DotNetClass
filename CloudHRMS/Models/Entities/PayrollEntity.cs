using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudHRMS.Models.Entities
{
    [Table("Payroll")]
    public class PayrollEntity:BaseEntity
	{
		public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public decimal IncomeTax { get; set; }

        public decimal GrossPay { get; set; }

        public decimal NetPay { get; set; }

        public decimal Allowance { get; set; }

        public decimal Deduction { get; set; }

        public decimal AttendanceDays { get; set; }

        public decimal AttendanceDeduction { get; set; }

        //set foreign key
        public string EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual EmployeeEntity Employee { get; set; }

        //set foreign key
        public string DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public virtual DepartmentEntity Department { get; set; }
    }
}

