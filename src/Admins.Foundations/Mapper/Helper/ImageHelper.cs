using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admins.Foundations.Mapper.Helper
{
    public static class ImageHelper
    {
        public static string UploadFileWithUniqueName(IFormFile iFormFile, string uploadFolder)
        {
            string uniqueFileName = Convert.ToString(DateTime.Now.ToString("dd MMM yyyy") + "_" +
                Guid.NewGuid() + "_" + iFormFile.FileName);
            string FilePath = Convert.ToString(Path.Combine(uploadFolder, uniqueFileName));
            iFormFile.CopyTo(new FileStream(FilePath, FileMode.Create));
            return uniqueFileName;
        }

        public static string UploadFileWithoutUniqueName(IFormFile iFormFile, string uploadFolder)
        {
            string FilePath = Convert.ToString(Path.Combine(uploadFolder, iFormFile.FileName));
            iFormFile.CopyTo(new FileStream(FilePath, FileMode.Create));
            return iFormFile.FileName;
        }

        public static string UploadBase64ToFolder(string FileName, string Base64String)
        {
            FileInfo fileInfo = new FileInfo(FileName);
            string FileLocation = String.Empty;
            if (FileFolderInfo(fileInfo.Extension) != String.Empty)
            {
                FileLocation = Convert.ToString(FileFolderInfo(fileInfo.Extension) + FileName);
                byte[] FileBytes = Convert.FromBase64String(Base64String);
                using (var FileStream = new FileStream(FileLocation, FileMode.Create, FileAccess.Write))
                {
                    FileStream.Write(FileBytes, 0, FileBytes.Length);
                    FileStream.Flush();
                }
            }
            return FileLocation;
        }

        public static void DeleteFile(string FilePath)
        {
            if (System.IO.File.Exists(FilePath))
            {
                System.IO.File.Delete(FilePath);
            }
        }

        public static string FileFolderInfo(string Extension)
        {
            if (Extension == ".doc" || Extension == ".docm" || Extension == ".docx")
                return "";
            else if (Extension == ".xlsx" || Extension == ".xls" || Extension == ".xlsm" || Extension == ".xlsb")
                return "";
            else if (Extension == ".png" || (Extension == ".jpeg" || Extension == ".jpg") || Extension == ".bmp")
                return "";
            else if (Extension == ".pdf")
                return "";
            else
                return String.Empty;
        }

    }
}
