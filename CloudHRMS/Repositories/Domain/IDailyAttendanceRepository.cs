﻿using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Repositories.Common;

namespace CloudHRMS.Repositories.Domain
{
    public interface IDailyAttendanceRepository:IBaseRepository<DailyAttendanceEntity>
    {
        IList<DepartmentViewModel> bindDepartmentData();
        IList<EmployeeViewModel> bindEmployeeData();
    }
}
