using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.Utility.Services {
    public interface IFileService {
        string CreateImg(IFormFile path);
        bool DeleImg(string? path);
    }
}
