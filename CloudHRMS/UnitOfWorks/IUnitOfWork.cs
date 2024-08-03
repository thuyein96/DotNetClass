using CloudHRMS.Repositories.Domain;

namespace CloudHRMS.UnitOfWorks
{
    public interface IUnitOfWork
    {
        //Register/Declare here for your repository Domains as A Unit Or Work
        IPositionRepository PositionRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        //Commit stages (insert, update, delete)
        void Commit();
        //Rollback transaction
        void Rollback();
    }
}
