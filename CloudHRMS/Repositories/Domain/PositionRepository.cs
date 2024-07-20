using CloudHRMS.DAO;
using CloudHRMS.Models.Entities;
using CloudHRMS.Repositories.Common;

namespace CloudHRMS.Repositories.Domain
{
    public class PositionRepository : BaseRepository<PositionEntity>, IPositionRepository
    {
        private readonly CloudHRMSApplicationDbContext _cloudHRMSApplicationDbContext;

        public PositionRepository(CloudHRMSApplicationDbContext cloudHRMSApplicationDbContext) : 
            base(cloudHRMSApplicationDbContext) //Constructor changing
        {
            _cloudHRMSApplicationDbContext = cloudHRMSApplicationDbContext;
        }

        public bool IsAlreadyExist(string Code, string Name)
        {
            return _cloudHRMSApplicationDbContext.Positions.Where(w => (w.Code != Code || w.Name == Name) && !w.IsInActive).Any();
            
        }
        // code your custom implementation for position functions
    }
}
