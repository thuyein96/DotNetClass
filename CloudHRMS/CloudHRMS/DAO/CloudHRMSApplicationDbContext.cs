using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace CloudHRMS.DAO
{
    public class CloudHRMSApplicationDbContext:DbContext
    {
        //Constructor changing to parent
        public CloudHRMSApplicationDbContext(DbContextOptions<CloudHRMSApplicationDbContext> options):base(options) {}
        //Register the DBSet Entities / Domain object to interface the database tables 
        public DbSet<PositionEntity>   Positions { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<AttendancePolicyEntity> AttendancePolicies { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<DailyAttendanceEntity> DailyAttendances { get; set; }
        public DbSet<ShiftEntity> Shifts { get; set; }
    }
}
