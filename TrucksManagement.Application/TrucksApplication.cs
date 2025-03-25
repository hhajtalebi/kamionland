using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using TrucksManagement.Application.contracts.TrkCategoryApplication;
using TrucksManagement.Application.contracts.TrucksApplication;
using TrucksManagement.Domain.TruckAgg;

namespace TrucksManagement.Application
{
    public class TrucksApplication:ITrucksApplication
    {
        private readonly ITruckRepository _truckRepository;
        private readonly IFileUploader _fileUploader;
        private readonly ITrkCategoryApplication _truckCategoryApplication;

        public TrucksApplication(ITruckRepository truckRepository, IFileUploader fileUploader, ITrkCategoryApplication truckCategoryApplication)
        {
            _truckRepository = truckRepository;
            _fileUploader = fileUploader;
            _truckCategoryApplication = truckCategoryApplication;
        }
        public OperationResulte Create(CreateTruck command)
        {
            OperationResulte resulte = new OperationResulte();
             var slug= command.Slug.Slugify();
             var pathFilePicture = $"Truck";
             var filePictureName = _fileUploader.Upload(command.Picture,pathFilePicture);
             var truck = new Truck(command.Name, command.ShortDescription, command.Description, command.Code,
                 command.TruckModel, command.color, command.HasColor, command.Year, command.Manufacturer,
                 filePictureName, command.PictureTitel, command.PrictureAlte, command.Keywords, command.MetaDescription,
                 slug, command.CategoryId);
             _truckRepository.Create(truck);
             _truckRepository.SaveChanges();
             return resulte.Succedded();

        }

        public OperationResulte Edit(EditTruck command)
        {
           OperationResulte resulte=new OperationResulte();
           var truck = _truckRepository.GetById(command.Id);
           if (truck == null)
               return resulte.Failed(ApplicationMeasages.RecordNotFound);
           var slug = command.Slug.Slugify();
           var pathFilePicture = $"Picture";
           if (command.PictureName!="")
               command.PictureName = _fileUploader.Upload(command.Picture, pathFilePicture);
           truck.Edit(command.Name, command.ShortDescription, command.Description, command.Code,
               command.TruckModel, command.color, command.HasColor, command.Year, command.Manufacturer,
               command.PictureName, command.PictureTitel, command.PrictureAlte, command.Keywords, command.MetaDescription,
               slug, command.CategoryId);

           _truckRepository.SaveChanges();
           return resulte.Succedded();
        }

        public EditTruck GetDetails(long id)
        {
            return _truckRepository.GetDetails(id);
        }

        public TruckViewModel? GetTruckBySlug(string slug)
        {
            return _truckRepository.GetTruckBySlug(slug);
        }
        public List<TruckViewModel> GetTrucks()
        {
            return _truckRepository.GetTrucks();
        }

        public List<TruckViewModel>? GetTrucks(long categoryId)
        {
            return _truckRepository.GetTrucks(categoryId);
        }
    }
}
