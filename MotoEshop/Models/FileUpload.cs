using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop.Models
{
    public class FileUpload
    {
        string RootPath;
        string ContentType;
        string FolderName;

        public FileUpload(string rootPath, string folderName, string contentType)
        {
            this.RootPath = rootPath;
            this.ContentType = contentType;
            this.FolderName = folderName;
        }

        public bool CheckFileContent(IFormFile iformFile)
        {
            return iformFile != null && iformFile.ContentType.ToLower().Contains(ContentType);
        }
        public bool CheckFileLength(IFormFile iformFile)
        {
            return iformFile.Length > 0 && iformFile.Length < 2_000_000;
        }

        public async Task<string> FileUploadAsync(IFormFile iformFile)
        {
            string filePathOutput = String.Empty;
            var img = iformFile;

            if (CheckFileContent(iformFile) && CheckFileLength(iformFile))
            {
                var fileName = Path.GetFileNameWithoutExtension(img.FileName);
                var fileExtension = Path.GetExtension(img.FileName);
                var fileNameGenerated = Path.GetRandomFileName();
                var fileRelative = Path.Combine(ContentType + "s", FolderName, fileName + fileExtension);
                var filePath = Path.Combine(RootPath, fileRelative);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await img.CopyToAsync(stream);
                }
                filePathOutput = $"/{fileRelative}";
            }
            return filePathOutput;
        }
    }
}

