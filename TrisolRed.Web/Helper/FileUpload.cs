using Microsoft.Extensions.Hosting.Internal;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace TrisolRed.Web.Helper
{
    public static class FileUpload
    {
        private static string ProcessUploadFile(IFormFile model, IHostingEnvironment hostingEnvironment)
        {
            string uniqueFileName = null;
            if (model != null)
            {
                string photoUpload = Path.Combine(hostingEnvironment.WebRootPath, "Image");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileName;
                string filePath = Path.Combine(photoUpload, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
