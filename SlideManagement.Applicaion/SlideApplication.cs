using _0_Framework.Application;
using SlideManagement.Applicaion.Contracts.SlideApplication;
using SlideManagement.Domain.SlideAgg;


namespace SlideManagement.Applicaion
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IFileUploader _fileUploader;
      
        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _slideRepository = slideRepository;
            _fileUploader = fileUploader;
            
        }
        public OperationResulte Create(CreateSlideApplication command)
        {
            var operation = new OperationResulte();

            var path = "slides";
            var PictureName = _fileUploader.UploadNewSizeFromWightAndHeight(command.Picture, path,780,441);
            var PictureNamefull = _fileUploader.UploadNewSizeFromWightAndHeight(command.Picture, path,480,400);
            var PictureNamethum = _fileUploader.UploadNewSizeFromWightAndHeight(command.Picture, path, 370,205);

            var slide = new Slide(PictureName,PictureNamefull, PictureNamethum, command.PictureAlte, command.PictureTitel, command.Titel,
                command.BtnText, command.Heading, command.Text, command.Link,command.CategoryId,command.CanonicalId);

            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResulte Update(EditSlideApplication command)
        {
            var operation = new OperationResulte();
            var slide = _slideRepository.GetById(command.Id);
            if (slide == null)
                return operation.Failed(ApplicationMeasages.RecordNotFound);
            
            var PictureName = command.pictureName;
            var PictureNameThum = command.pictureNamethum;
            var PictureNamefull = "";
            if (command.Picture != null)
            {
                if (command.pictureName != null || command.pictureNamethum != null)
                {
                    _fileUploader.Delete(command.pictureName);
                    _fileUploader.Delete(command.pictureNamethum);
                }
            }

            if (command.Picture != null)
            {
                var path = "slides";
                 PictureName = _fileUploader.UploadNewSizeFromWightAndHeight(command.Picture, path, 780, 441);
                 PictureNameThum = _fileUploader.UploadNewSizeFromWightAndHeight(command.Picture, path, 370, 205);
                  PictureNamefull = _fileUploader.UploadNewSizeFromWightAndHeight(command.Picture, path, 480, 400);

            }

            slide.Edit(PictureName,PictureNamefull, PictureNameThum, command.PictureAlte, command.PictureTitel, command.Titel,
                command.BtnText, command.Heading, command.Text, command.Link,command.CategoryId,command.CanonicalId);

            _slideRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResulte Delete(long id)
        {
            var operation = new OperationResulte();
            var slide = _slideRepository.GetById(id);
            if (slide == null)
                return operation.Failed(ApplicationMeasages.RecordNotFound);

            slide.Delete();
            _slideRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResulte Restore(long id)
        {
            var operation = new OperationResulte();
            var slide = _slideRepository.GetById(id);
            if (slide == null)
                return operation.Failed(ApplicationMeasages.RecordNotFound);

            slide.Restore();
            _slideRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditSlideApplication GetDetailes(long id)
        {
            return _slideRepository.GetDetailes(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }
    }
}
