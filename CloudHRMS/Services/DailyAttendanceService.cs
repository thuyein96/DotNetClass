using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
namespace CloudHRMS.Services
{
    public class DailyAttendanceService : IDailyAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DailyAttendanceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void Create(DailyAttendanceViewModel dailyAttendanceViewModel)
        {
            //Data exchange from view model to data model
            DailyAttendanceEntity dailyAttendanceEntity = new DailyAttendanceEntity()
            {
                Id = Guid.NewGuid().ToString(),
                AttendanceDate = dailyAttendanceViewModel.AttendanceDate,
                InTime = dailyAttendanceViewModel.InTime,
                OutTime = dailyAttendanceViewModel.OutTime,
                EmployeeId = dailyAttendanceViewModel.EmployeeId,
                DepartmentId = dailyAttendanceViewModel.DepartmentId,
                CreatedAt = DateTime.Now
            };
            _unitOfWork.DailyAttendanceRepository.Create(dailyAttendanceEntity);//store the object in dbSets
            _unitOfWork.Commit();//actually commit/save the data to the database
        }

        public bool Delete(string Id)
        {
            try
            {
                var entity = _unitOfWork.DailyAttendanceRepository.GetBy(x => x.Id == Id).SingleOrDefault();
                if (entity != null)
                {
                    entity.IsInActive = true;
                    _unitOfWork.DailyAttendanceRepository.Delete(entity);
                    _unitOfWork.Commit();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<DailyAttendanceViewModel> GetAll()
        {
            return (from da in _unitOfWork.DailyAttendanceRepository.GetAll()
                  join d in _unitOfWork.DepartmentRepository.GetAll()
                  on da.DepartmentId equals d.Id
                  join e in _unitOfWork.EmployeeRepository.GetAll()
                  on da.EmployeeId equals e.Id
                  where !da.IsInActive && !d.IsInActive && !e.IsInActive
                  select new DailyAttendanceViewModel
                  {
                      Id = da.Id,
                      AttendanceDate = da.AttendanceDate,
                      InTime = da.InTime,
                      OutTime = da.OutTime,
                      EmployeeInfo = e.Code + "/" + e.Name,
                      DepartmentInfo = d.Code + "/" + d.Name
                  }).ToList();
        }

        public DailyAttendanceViewModel GetById(string id)
        {
            return _unitOfWork.DailyAttendanceRepository.GetBy(w => w.Id == id && !w.IsInActive).Select(s => new DailyAttendanceViewModel
            {
                Id = s.Id,
                AttendanceDate = s.AttendanceDate,
                InTime = s.InTime,
                OutTime = s.OutTime,
                DepartmentId = s.DepartmentId,
                EmployeeId = s.EmployeeId,
                CreatedOn = s.CreatedAt,
                UpdatedOn = s.ModifiedAt
            }).FirstOrDefault();
        }

        public void Update(DailyAttendanceViewModel dailyAttendanceViewModel)
        {
            DailyAttendanceEntity dailyAttendance = new DailyAttendanceEntity()
            {
                Id = dailyAttendanceViewModel.Id,
                AttendanceDate = dailyAttendanceViewModel.AttendanceDate,
                InTime = dailyAttendanceViewModel.InTime,
                OutTime = dailyAttendanceViewModel.OutTime,
                EmployeeId = dailyAttendanceViewModel.EmployeeId,
                DepartmentId = dailyAttendanceViewModel.DepartmentId,
                ModifiedAt = DateTime.Now,
                CreatedAt = dailyAttendanceViewModel.CreatedOn
            };
            _unitOfWork.DailyAttendanceRepository.Update(dailyAttendance);
            _unitOfWork.Commit();
        }

        public IList<DepartmentViewModel> bindDepartmentData()
        {
            return _unitOfWork.DailyAttendanceRepository.bindDepartmentData();
        }

        public IList<EmployeeViewModel> bindEmployeeData()
        {
            return _unitOfWork.DailyAttendanceRepository.bindEmployeeData();
        }
    }
}
