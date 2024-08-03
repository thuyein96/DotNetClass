using CloudHRMS.Models.ReportModels;

namespace CloudHRMS.Reportings
{
    public class Reporting : IReporting
    {
        public IList<EmployeeDetail> EmployeeDetailReportBy(string fromEmployeeCode, string toEmployeeCode, string departmentCode)
        {
            throw new NotImplementedException();
        }
    }
}
