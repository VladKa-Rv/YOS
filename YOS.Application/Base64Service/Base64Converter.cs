using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace YOS.Application.Base64Service
{
    public static class Base64Converter
    {
        public static async Task<string> ToBase64StringAsync(this IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                var fileBytes = memoryStream.ToArray();

                return Convert.ToBase64String(fileBytes);
            }
        }

        public static string ToBase64String(this IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                var fileBytes = memoryStream.ToArray();

                return Convert.ToBase64String(fileBytes);
            }
        }

        public static FormFile FromBase64String(string fileName, string base64)
        {
            var bytes = Convert.FromBase64String(base64);
            var memoryStream = new MemoryStream(bytes);

            return new FormFile(memoryStream, 0, bytes.Length, fileName, fileName);
        }
    }
}
