using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.Utility.Services {
    public class FileService : IFileService {
        private readonly IHostingEnvironment _hosting;

        public FileService(IHostingEnvironment hosting)
        {
            _hosting = hosting;
        }

        public string CreateImg(IFormFile? path)
        {
            if (path == null)
            {
                string FolderMain = Path.Combine(_hosting.WebRootPath, "Images");
                string FileName = path.FileName;
                string FullPath=Path.Combine(FolderMain, FileName);
                if (!File.Exists(FullPath))
                {
                    File.Create(FullPath);
                }
                FileStream stream=new FileStream(FullPath, FileMode.Create);
                stream.CopyTo(stream);
                stream.Close();
                return FileName;
            }
            return "Images/Image-Not-Found .png";
        }
    }
}
