using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace LanchesMAC.Models
{
    public class FileManagerModel
    {
        public FileInfo[] Files { get; set; }
        public IFormFile IFormFile { get; set; }
        public List<IFormFile> IFormFiles { get; set; }
        public string PathImagensProdutos { get; set; }
    }
}
