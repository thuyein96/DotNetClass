using CloudHRMS.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudHRMS.Models.ViewModels
{
    public class PayrollViewModel
    {
        public string Id { get; set; }
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

        //set foreign key
        public string DepartmentId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}
