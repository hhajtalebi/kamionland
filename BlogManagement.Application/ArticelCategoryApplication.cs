using blogManagement.Application.Contracts.ArticelCategoryApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using BlogManagement.Domain.ArticelCategoryAgg;

namespace BlogManagement.Application
{
    public class ArticelCategoryApplication : IAricelCategoryApplication
    {
        private readonly IArticelCategoryRepository _articelCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ArticelCategoryApplication(IArticelCategoryRepository articelCategoryRepository, IFileUploader fileUploader)
        {
            _articelCategoryRepository = articelCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResulte Create(CreateArticelCategory command)
        {
            var operationResulte = new OperationResulte();

            if (_articelCategoryRepository.Exists(x => x.Name == command.Name))
                return operationResulte.Failed(ApplicationMeasages.DuplicatedRecord);

            var Slug = command.Slug.Slugify();
            var pictureName = _fileUploader.Upload(command.Picture, Slug);

            var ArticelCategory = new ArticelCategory(command.Name, command.Description, pictureName,command.PictureAlt,command.PictureTitle,
                command.ShowOrder, Slug, command.Keywords, command.MetaDescription, command.CanonicalAddress);

            _articelCategoryRepository.Create(ArticelCategory);
            _articelCategoryRepository.SaveChanges();
            return operationResulte.Succedded();
        }

        public OperationResulte Edit(EditArticelCategory command)
        {
            var operationResulte = new OperationResulte();

            var articelCategory = _articelCategoryRepository.GetById(command.Id);

            if (articelCategory == null)
                return operationResulte.Failed(ApplicationMeasages.RecordNotFound);
            if (_articelCategoryRepository.Exists(x => x.Name == command.Name && x.Id == command.Id))
                return operationResulte.Failed(ApplicationMeasages.DuplicatedRecord);

            var Slug = command.Slug.Slugify();
            var pictureName = _fileUploader.Upload(command.Picture, Slug);

            articelCategory.Edit(command.Name, command.Description, pictureName, command.PictureAlt, command.PictureTitle,
                command.ShowOrder, Slug, command.Keywords, command.MetaDescription, command.CanonicalAddress);

            _articelCategoryRepository.SaveChanges();
            return operationResulte.Succedded();
        }

        public EditArticelCategory? GetDetails(long id)
        {
            return _articelCategoryRepository.GetDetails(id);
        }

        public List<ArticelCategoryViewModel> Search(ArticelCategorySearchModel searchModel)
        {
            return _articelCategoryRepository.Search(searchModel);
        }

        public List<ArticelCategoryViewModel> GetArticleCategories()
        {
            return _articelCategoryRepository.GetArticleCategories();
        }
    }
}
