using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JobResearchSystem.Application.Helper
{
    public static class HandelFiles
    {
        // private static readonly IConfiguration config;

        public static async Task<(bool, string)> UploadFile(IFormFile file)
        {
            try
            {
                string FolderPath = Directory.GetCurrentDirectory();

                string FileName = Guid.NewGuid() + Path.GetFileName(file.FileName.Replace(' ', '-'));

                string fileExtension = Path.GetExtension(file.FileName);

                var imageAllowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
                var cvAllowedExtensions = new string[] { ".pdf" };

                var isImageType = imageAllowedExtensions.Contains(fileExtension);
                var isCvType = cvAllowedExtensions.Contains(fileExtension);


                using IHost host = Host.CreateDefaultBuilder().Build();
                IConfiguration config = host.Services.GetRequiredService<IConfiguration>();


                if (file.Length >= 5 * 1024 * 1024)
                    return (false, "File Size is Greater Than 5 MB");


                if (isImageType) //Check Extension
                {
                    FolderPath = FolderPath + config["FilePaths:ImagesPath"]; // get Storage Location from App Setting                 
                }
                else
                if (isCvType) //Check Extension
                {
                    FolderPath = FolderPath + config["FilePaths:CvsPath"]; // get Storage Location from App Setting
                }
                else return (false, "Unsupported file extension");


                var FinalPath = Path.Combine(FolderPath, FileName);

                using (var stream = new FileStream(FinalPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return (true, FileName);
            }
            catch (Exception ex)
            { return (false, ex.Message); }
        }

        ////////////////////////////////////////////////////////////////////////

        public static async Task RemoveFile(string FileName, string type)
        {
            string CurrentDirectory = Directory.GetCurrentDirectory();
            string FolderPath = "";

            //Remove Image
            using IHost host = Host.CreateDefaultBuilder().Build();
            IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

            if (type == "cv")
            {
                FolderPath = config["FilePaths:CvsPath"];
            }
            if (type == "image")
            {
                FolderPath = config["FilePaths:ImagesPath"];
            }

            var path = CurrentDirectory + Path.Combine(FolderPath, FileName);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

    }
}
