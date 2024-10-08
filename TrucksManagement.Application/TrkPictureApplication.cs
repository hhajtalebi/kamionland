using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using TrucksManagement.Application.contracts.TrkPictureApplication;
using TrucksManagement.Domain.TruckAgg;
using TrucksManagement.Domain.TruckPictureAgg;

namespace TrucksManagement.Application
{
    
    public class TrkPictureApplication: ITrkPictureApplication
    {
        private readonly ITruckPictureRepository _truckPictureRepository;
        private readonly ITruckRepository _truckRepository;
        private readonly IFileUploader _fileUploader;

        public TrkPictureApplication(ITruckPictureRepository truckPictureRepository, ITruckRepository truckRepository, IFileUploader fileUploader)
        {
            _truckPictureRepository = truckPictureRepository;
            _truckRepository = truckRepository;
            _fileUploader = fileUploader;
        }
        public OperationResulte Create(CreateTrkPicture command)
        {
            OperationResulte resulte = new OperationResulte();
            var pathFileName = $"TruckPicture";
            var FileName = _fileUploader.Upload(command.Picture, pathFileName);
            var picture = new TruckPicture(command.TruckId, FileName, command.PictureAlte, command.PictureTitel);
            _truckPictureRepository.Create(picture);
            _truckPictureRepository.SaveChanges();
            return resulte.Succedded();
        }

        public OperationResulte Edit(EditTrkPicture command)
        {
            OperationResulte resulte=new OperationResulte();
            var picture = _truckPictureRepository.GetTructPictureWithTruckAndCategory(command.Id);
            if (picture == null)
                return resulte.Failed(ApplicationMeasages.RecordNotFound);
            var pathFileName = $"Picture";
            var FileName = _fileUploader.Upload(command.Picture, pathFileName);

            picture.Edit(command.TruckId,FileName,command.PictureAlte,command.PictureTitel);
            _truckPictureRepository.SaveChanges();
            return resulte.Succedded();
        }

        public EditTrkPicture GetDetails(long id)
        {
            return _truckPictureRepository.GetDetails(id);

        }

        public List<TrkPictureViewModel> GetTrkPicture()
        {
            return _truckPictureRepository.TrkPicturesList();
        }

        public OperationResulte Delete(long id)
        {
            OperationResulte resulte = new OperationResulte();
            var picture = _truckPictureRepository.GetTructPictureWithTruckAndCategory(id);
            if (picture == null)
                return resulte.Failed(ApplicationMeasages.RecordNotFound);
            picture.Delete();
            _truckPictureRepository.SaveChanges();
            return resulte.Succedded();

        }

        public OperationResulte Restore(long id)
        {
            OperationResulte resulte = new OperationResulte();
            var picture = _truckPictureRepository.GetTructPictureWithTruckAndCategory(id);
            if (picture == null)
                return resulte.Failed(ApplicationMeasages.RecordNotFound);
            picture.restor();
            _truckPictureRepository.SaveChanges();
            return resulte.Succedded();
        }
    }
}
