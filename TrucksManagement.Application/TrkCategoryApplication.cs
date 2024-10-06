using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using TrucksManagement.Application.contracts.TrkCategoryApplication;
using TrucksManagement.Domain.TruckCategoryAgg;

namespace TrucksManagement.Application
{
    public class TrkCategoryApplication: ITrkCategoryApplication
    {
        private readonly ITruckCategoryRepository _truckCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public TrkCategoryApplication(ITruckCategoryRepository truckCategoryRepository, IFileUploader fileUploader)
        {
            _truckCategoryRepository = truckCategoryRepository;
            _fileUploader = fileUploader;
        }
        public OperationResulte Create(CreateTrkCategory command)
        {
            OperationResulte resulte = new OperationResulte();
            var slug=command.Slug.Slugify();
            var pathFilePicture = $"Picture";
            var fileName = _fileUploader.Upload(command.Picture, pathFilePicture);
            var TrkCategory = new TruckCategory(command.Name, command.Description, fileName, command.PictureAlt,
                command.PictureTitel, command.keyword, command.MetaDescription, slug, command.ParentId);
            _truckCategoryRepository.Create(TrkCategory);
            _truckCategoryRepository.SaveChanges();
            return resulte.Succedded();



        }

        public OperationResulte Edit(EditTrkCategory command)
        {
            OperationResulte resulte = new OperationResulte();

            var category = _truckCategoryRepository.GetById(command.Id);
            if (category == null)
                return resulte.Failed(ApplicationMeasages.RecordNotFound);
            var slug = command.Slug.Slugify();
            var pathFilePicture = $"Picture";
            var fileName = _fileUploader.Upload(command.Picture, pathFilePicture);
            category.Edit(command.Name, command.Description, fileName, command.PictureAlt,
                command.PictureTitel, command.keyword, command.MetaDescription, slug, command.ParentId);
           _truckCategoryRepository.SaveChanges();
           return resulte.Succedded();
        }

        public EditTrkCategory GetDetailes(long id)
        {
            throw new NotImplementedException();
        }

        public List<TrkCategoryViewModel> GetTrkCategorys()
        {
            throw new NotImplementedException();
        }
    }
}
