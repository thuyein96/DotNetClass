using CloudHRMS.DAO;
using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Repositories.Common;

namespace CloudHRMS.Repositories.Domain
{
    public class EmployeeRepository : BaseRepository<EmployeeEntity>, IEmployeeRepository
    {
        private readonly CloudHRMSApplicationDbContext _cloudHRMSApplicationDbContext;

        public EmployeeRepository(CloudHRMSApplicationDbContext cloudHRMSApplicationDbContext) : base(cloudHRMSApplicationDbContext)//Constructor changing
        {
            _cloudHRMSApplicationDbContext = cloudHRMSApplicationDbContext;
        }
        //code your custom implemenation for position functions 
        public bool IsAlreadyExist(string Code, string Name)=> _cloudHRMSApplicationDbContext.Employees.Where(w => (w.Code != Code && w.Name == Name) && !w.IsInActive).Any();

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

        public IList<PositionViewModel> bindPositionData()
        {
            IList<PositionViewModel> positions = _cloudHRMSApplicationDbContext.Positions.Where(w => !w.IsInActive).Select(s =>
             new PositionViewModel
             {
                 Id = s.Id,
                 Code = s.Code + "/" + s.Name
             }).ToList();
            return positions;

        }
    }
}
