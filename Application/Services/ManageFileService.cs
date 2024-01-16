using Domain.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ManageFileService : IManageFileService
    {
        public async Task<string> UploadFile(IFormFile formFile)
        {
            try
            {
                if (formFile == null || formFile.Length == 0)
                {
                    throw new ArgumentException("Invalid file");
                }

                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                string filePath = Path.Combine(GetStaticContentDirectory(), uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }

                return uniqueFileName;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine($"Error uploading file: {ex.Message}");
                throw; // Rethrow the exception after logging or handling
            }

        }

        public async Task<(byte[], string, string)> DownloadFile(string fileName)
        {
            try
            {
                // Combine the requested file name with the path to the static content directory
                string filePath = Path.Combine(GetStaticContentDirectory(), fileName);

                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("File not found", fileName);
                }

                // Determine the content type based on the file extension
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(filePath, out var contentType))
                {
                    contentType = "application/octet-stream";
                }

                // Read the file content into a byte array
                var fileBytes = await File.ReadAllBytesAsync(filePath);

                return (fileBytes, contentType, fileName);
            }
            catch (Exception ex)
            {
                // Handle the exception or log it appropriately
                throw;
            }
        }

        private static string GetStaticContentDirectory()
        {
            string directory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "StaticContent");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return directory;
        }
    }

}
