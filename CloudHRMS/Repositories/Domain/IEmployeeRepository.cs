using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Repositories.Common;

namespace CloudHRMS.Repositories.Domain
{
    public interface IEmployeeRepository:IBaseRepository<EmployeeEntity>
    {
        //customization code logic here 
        bool IsAlreadyExist(string Code, string Name);
        IList<DepartmentViewModel> bindDepartmentData();
        IList<PositionViewModel> bindPositionData();
    }
}
