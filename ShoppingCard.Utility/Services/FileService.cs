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

        public string CreateImg(IFormFile path)
        {
            if (path != null)
            {
                string FolderMain = Path.Combine(_hosting.WebRootPath, "Images");
                if (!Directory.Exists(FolderMain))
                {
                    Directory.CreateDirectory(FolderMain);
                }
                string Name = path.FileName;
                string FullPath=Path.Combine(FolderMain, Name);
                FileStream stream=new FileStream(FullPath, FileMode.Create);
                path.CopyTo(stream);
                stream.Close();
                return Name;
            }
            return null;
        }

        public bool DeleImg(string? path)
        {
            if (path != null)
            {
                string FolderMain = Path.Combine(_hosting.WebRootPath, "Images");
                string FullPath = Path.Combine(FolderMain, path);
                if (System.IO.File.Exists(FullPath))
                {
                    System.IO.File.Delete(FullPath);
                    return true;
                }
            }
            return false;
        }
    }
}
