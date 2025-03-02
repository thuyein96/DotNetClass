﻿using CloudHRMS.DAO;
using CloudHRMS.Repositories.Domain;

namespace CloudHRMS.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CloudHRMSApplicationDbContext _cloudHRMSApplicationDbContext;

        public UnitOfWork(CloudHRMSApplicationDbContext cloudHRMSApplicationDbContext)
        {
            _cloudHRMSApplicationDbContext = cloudHRMSApplicationDbContext;
        }

        //properties to create repository instance of class for Unit Of Work
        private  IPositionRepository _positionRepository;
        public IPositionRepository PositionRepository
        {
            get
            {
                return _positionRepository = _positionRepository ?? new PositionRepository(_cloudHRMSApplicationDbContext);
            }
        }

        //properties to create repository instance of class for Unit Of Work
        private IDepartmentRepository _departmentRepository;
        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                return _departmentRepository = _departmentRepository ?? new DepartmentRepository(_cloudHRMSApplicationDbContext);
            }
        }

        private IEmployeeRepository _employeeRepository;
        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                return _employeeRepository = _employeeRepository ?? new EmployeeRepository(_cloudHRMSApplicationDbContext);
            }
        }

        private IDailyAttendanceRepository _dailyAttendanceRepository;
        public IDailyAttendanceRepository DailyAttendanceRepository
        {
            get
            {
                return _dailyAttendanceRepository = _dailyAttendanceRepository ?? new DailyAttendanceRepository(_cloudHRMSApplicationDbContext);
            }
        }

        public void Commit()
        {
            _cloudHRMSApplicationDbContext.SaveChanges();
        }

        public void Rollback()
        {
            _cloudHRMSApplicationDbContext.Dispose();
        }
    }
}
