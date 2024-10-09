using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public interface IFileUploader
    {
        string Upload(IFormFile file, string Path);
        public string UploadNewSize(IFormFile file, string Path, int wight);
        public string UploadNewSizeFromWightAndHeight(IFormFile file, string Path, int wight, int Height);
        public void Delete(string pictureName);
    }
}
