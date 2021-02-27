using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritionist.Web.Infrastructure
{
    public static class StaticFunctions
    {
        public static byte[] GetBytesFromFile(IFormFile formFile)
        {
            if (formFile == null)
            {
                return null;
            }
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
