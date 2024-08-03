using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
namespace CloudHRMS.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void Create(EmployeeViewModel employeeViewModel)
        {
            //Data exchange from view model to data model
            var employee = new EmployeeEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Code = employeeViewModel.Code,
                Name = employeeViewModel.Name,
                Email = employeeViewModel.Email,
                Gender = employeeViewModel.Gender,
                DOB = employeeViewModel.DOB,
                DOE = employeeViewModel.DOE,
                DOR = employeeViewModel.DOR,
                Address = employeeViewModel.Address,
                BasicSalary = employeeViewModel.BasicSalary,
                ExtensionPhone = employeeViewModel.ExtensionPhone,
                PositionId = employeeViewModel.PositionId,
                DepartmentId = employeeViewModel.DepartmentId,
                CreatedAt = DateTime.Now
            };
            _unitOfWork.EmployeeRepository.Create(employee);//store the object in dbSets
            _unitOfWork.Commit();//actually commit/save the data to the database
        }

        public bool Delete(string Id)
        {
            try
            {
                var entity = _unitOfWork.EmployeeRepository.GetBy(x => x.Id == Id).SingleOrDefault();
                if (entity != null)
                {
                    entity.IsInActive = true;
                    _unitOfWork.EmployeeRepository.Delete(entity);
                    _unitOfWork.Commit();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return (from e in _unitOfWork.EmployeeRepository.GetAll()
                  join d in _unitOfWork.DepartmentRepository.GetAll()
                  on e.DepartmentId equals d.Id
                  join p in _unitOfWork.PositionRepository.GetAll()
                  on e.PositionId equals p.Id
                  where !e.IsInActive && !d.IsInActive && !p.IsInActive
                  select new EmployeeViewModel
                  {
                      Id = e.Id,
                      Code = e.Code,
                      Name = e.Name,
                      Email = e.Email,
                      Gender = e.Gender,
                      DOB = e.DOB,
                      DOE = e.DOE,
                      DOR = e.DOR,
                      Address = e.Address,
                      BasicSalary = e.BasicSalary,
                      ExtensionPhone = e.ExtensionPhone,
                      DepartmentInfo = d.Code + "/" + d.Name,
                      PositionInfo = p.Code + "/" + p.Name
                  }).ToList();
        }

        public EmployeeViewModel GetById(string id)
        {
            return _unitOfWork.EmployeeRepository.GetBy(w => w.Id == id && !w.IsInActive).Select(s => new EmployeeViewModel
            {
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Email = s.Email,
                Gender = s.Gender,
                DOB = s.DOB,
                DOE = s.DOE,
                DOR = s.DOR,
                Address = s.Address,
                BasicSalary = s.BasicSalary,
                ExtensionPhone = s.ExtensionPhone,
                DepartmentId = s.DepartmentId,
                PositionId = s.PositionId,
                CreatedOn = s.CreatedAt,
                UpdatedOn = s.ModifiedAt
            }).FirstOrDefault();
        }

        public bool IsAlreadyExist(EmployeeViewModel vm)
        {
            return _unitOfWork.EmployeeRepository.IsAlreadyExist(vm.Code, vm.Name);
        }

        public void Update(EmployeeViewModel employeeViewModel)
        {
            var employee = new EmployeeEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Code = employeeViewModel.Code,
                Name = employeeViewModel.Name,
                Email = employeeViewModel.Email,
                Gender = employeeViewModel.Gender,
                DOB = employeeViewModel.DOB,
                DOE = employeeViewModel.DOE,
                DOR = employeeViewModel.DOR,
                Address = employeeViewModel.Address,
                BasicSalary = employeeViewModel.BasicSalary,
                ExtensionPhone = employeeViewModel.ExtensionPhone,
                PositionId = employeeViewModel.PositionId,
                DepartmentId = employeeViewModel.DepartmentId,
                CreatedAt = DateTime.Now
            };
            _unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Commit();
        }

        public IList<DepartmentViewModel> bindDepartmentData()
        {
            return _unitOfWork.EmployeeRepository.bindDepartmentData();
        }

        public IList<PositionViewModel> bindPositionData()
        {
            return _unitOfWork.EmployeeRepository.bindPositionData();
        }
    }
}
