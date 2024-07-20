using CloudHRMS.Models.Entities;
using CloudHRMS.Repositories.Common;

namespace CloudHRMS.Repositories.Domain
{
    public interface IPositionRepository : IBaseRepository<PositionEntity>
    {
        //Custuminzation code
        bool IsAlreadyExist(string Code, string Name);
    }
}
