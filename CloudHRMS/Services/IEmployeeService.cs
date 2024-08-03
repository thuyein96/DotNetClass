using CloudHRMS.Models.ViewModels;

namespace CloudHRMS.Services
{
    public interface IEmployeeService
    {
        //Create 
        void Create(EmployeeViewModel vm);
        //Reterive
        IEnumerable<EmployeeViewModel> GetAll();
        //GetById
        EmployeeViewModel GetById(string id);
        //Update 
        void Update(EmployeeViewModel vm);
        //delete 
        bool Delete(string Id);
        //checking already exist data 
        bool IsAlreadyExist(EmployeeViewModel vm);
        IList<DepartmentViewModel> bindDepartmentData();
        IList<PositionViewModel> bindPositionData();
    }
}
