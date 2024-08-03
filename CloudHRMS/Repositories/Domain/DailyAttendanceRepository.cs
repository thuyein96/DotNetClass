using CloudHRMS.DAO;
using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Repositories.Common;

namespace CloudHRMS.Repositories.Domain
{
    public class DailyAttendanceRepository : BaseRepository<DailyAttendanceEntity>, IDailyAttendanceRepository
    {
        private readonly CloudHRMSApplicationDbContext _cloudHRMSApplicationDbContext;

        public DailyAttendanceRepository(CloudHRMSApplicationDbContext cloudHRMSApplicationDbContext) : base(cloudHRMSApplicationDbContext)//Constructor changing
        {
            _cloudHRMSApplicationDbContext = cloudHRMSApplicationDbContext;
        }

        public IList<DepartmentViewModel> bindDepartmentData()
        {
            IList<DepartmentViewModel> departments = _cloudHRMSApplicationDbContext.Departments.Where(w => !w.IsInActive).Select(s =>
            new DepartmentViewModel
            {
                Id = s.Id,
                Code = s.Code + "/" + s.Name
            }).ToList();
            return departments;
        }

        public IList<EmployeeViewModel> bindEmployeeData()
        {
            IList<EmployeeViewModel> employees = _cloudHRMSApplicationDbContext.Employees.Where(w => !w.IsInActive).Select(s =>
             new EmployeeViewModel
             {
                 Id = s.Id,
                 Code = s.Code + "/" + s.Name
             }).ToList();
            return employees;

        }
    }
}
