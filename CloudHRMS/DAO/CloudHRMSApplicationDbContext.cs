using CloudHRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudHRMS.DAO
{
    public class CloudHRMSApplicationDbContext :DbContext
    {
        public CloudHRMSApplicationDbContext(DbContextOptions<CloudHRMSApplicationDbContext> option):base(option)
        {
            
        }

        //Register entities
        public DbSet<PositionEntity> Positions { get; set; }
    }
}
