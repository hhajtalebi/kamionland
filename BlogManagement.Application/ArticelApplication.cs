﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using blogManagement.Application.Contracts.ArticelApplication;
using blogManagement.Application.Contracts.ArticelCategoryApplication;
using BlogManagement.Domain.ArticelAgg;
using BlogManagement.Domain.ArticelCategoryAgg;

namespace BlogManagement.Application
{
    public class ArticelApplication : IArticelApplication
    {
        private readonly IArticelRepository _articelRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IArticelCategoryRepository _articelCategoryRepository;

        public ArticelApplication(IArticelRepository articelRepository, IFileUploader fileUploader, IArticelCategoryRepository articelCategoryRepository)
        {
            _articelRepository = articelRepository;
            _fileUploader = fileUploader;
            _articelCategoryRepository = articelCategoryRepository;
        }
        public OperationResulte Create(CreateArticel comman)
        {
            var CategorySlug = _articelCategoryRepository.GetById(comman.ArticelCategoryId).Slug;
            var operationResulte = new OperationResulte();

            if (_articelRepository.Exists(x => x.Title == comman.Title))
                return operationResulte.Failed(ApplicationMeasages.DuplicatedRecord);

            var slug = comman.Slug.Slugify();
            var path = $"Blog/Articel";
            var pictureName = _fileUploader.UploadNewSize(comman.Picture, path, 860);
            var pictureNamethum = _fileUploader.UploadNewSize(comman.Picture, path, 200);

           

            var publishDate = comman.PublishDate.ToGeorgianDateTime();

            var articel = new Articel(comman.Title, comman.ShortDescription, comman.Description, pictureName,pictureNamethum,
                comman.PictureAlte
                , comman.PictureTitle, slug, comman.Keywords, comman.MetaDescription, comman.CanonicalAddress,
                publishDate, comman.ArticelCategoryId);

            _articelRepository.Create(articel);
            _articelRepository.SaveChanges();
            return operationResulte.Succedded();

        }

        public OperationResulte Edit(EditArticel comman)
        {
            var articel = _articelRepository.GetById(comman.Id);
            var CategorySlug = _articelCategoryRepository.GetById(comman.ArticelCategoryId).Slug;
            var operationResulte = new OperationResulte();
            if (articel == null)
                return operationResulte.Failed(ApplicationMeasages.RecordNotFound);
            if (_articelRepository.Exists(x => x.Title == comman.Title && x.Id != comman.Id))
                return operationResulte.Failed(ApplicationMeasages.DuplicatedRecord);
            var slug = comman.Slug.Slugify();


            var path = $"Blog/Articel";

            var pictureName = _fileUploader.UploadNewSize(comman.Picture, path, 860);
            var pictureNamethum = _fileUploader.UploadNewSize(comman.Picture, path, 200);

            var publishDate = comman.PublishDate.ToGeorgianDateTime();


            articel.Edit(comman.Title, comman.ShortDescription, comman.Description, pictureName,pictureNamethum,
                comman.PictureAlte
                , comman.PictureTitle, slug, comman.Keywords, comman.MetaDescription, comman.CanonicalAddress,
                publishDate, comman.ArticelCategoryId);

            _articelRepository.SaveChanges();
            return operationResulte.Succedded();
        }

        public EditArticel? GetDetails(long id)
        {
            return _articelRepository.GetDetails(id);

        }

        public List<ArticelViewModel>? GetArticelsByCategoryId(long categoryId)
        {
            return _articelRepository.GetArticelsByCategoryId(categoryId);
        }
        public List<ArticelViewModel> Search(ArticelSearchModel searches)
        {
          return _articelRepository.Search(searches);
        }

        public List<ArticelViewModel>? GetArticels()
        {
            return _articelRepository.GetArticels();
        }
    }
}
