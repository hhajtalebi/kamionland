using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using TrucksManagement.Application.contracts.TrkCategoryApplication;



namespace SlideManagement.Applicaion.Contracts.SlideApplication
{
    public class CreateSlideApplication
    {
        [MaxFileSize(5*1024*1024,ErrorMessage = ValidationMessages.FileSizeNotValid)]
        public IFormFile? Picture { get; set; }
        public string PictureAlte { get; set; }
        public string PictureTitel { get; set; }
        public string Titel { get; set; }
        public string Text { get; set; }
        public string BtnText { get; set; }
        public string Heading { get; set; }
        public  string Link { get; set; }
        public long? CategoryId { get;  set; }
        public long? CanonicalId { get; set; }
        public List<TrkCategoryViewModel> ListCategoresp { get; set; }
    }
}
