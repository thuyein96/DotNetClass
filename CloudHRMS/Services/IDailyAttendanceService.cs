using CloudHRMS.Models.ViewModels;

namespace CloudHRMS.Services
{
    public interface IDailyAttendanceService
    {
        //Create 
        void Create(DailyAttendanceViewModel vm);
        //Reterive
        IEnumerable<DailyAttendanceViewModel> GetAll();
        //GetById
        DailyAttendanceViewModel GetById(string id);
        //Update 
        void Update(DailyAttendanceViewModel vm);
        //delete 
        bool Delete(string Id);
        IList<DepartmentViewModel> bindDepartmentData();
        IList<EmployeeViewModel> bindEmployeeData();
    }
}
