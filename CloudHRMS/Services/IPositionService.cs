using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;

namespace CloudHRMS.Services
{
    public interface IPositionService
    {
        //Create
        void Create(PositionViewModel positionViewModel);
        //Retrieve
        IEnumerable<PositionViewModel> GetAll();
        //GetById
        PositionViewModel GetById(string id);
        //Update
        void Update(PositionViewModel positionViewModel);
        // Delete
        bool Delete(string  id);

        //checking 
        bool IsAlreadyExist(PositionViewModel positionViewModel);
    }
}
