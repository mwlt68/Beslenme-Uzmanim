using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nutritionist.Core.Helper
{
    public static class StaticFunctions
    {
        public static String DefaultUpperCase(String value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            else
            {
                String result = $"{Char.ToUpperInvariant(value[0])}";
                for (int i = 1; i < value.Length; i++)
                {
                    result += Char.ToLowerInvariant(value[i]);
                }
                return result;
            }
        }
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
        // Todo: this method not checked
        public static IFormFile GetFileFromBytes(byte[] byteArray)
        {
            if (byteArray == null)
            {
                return null;
            }
            var stream = new MemoryStream(byteArray);
            IFormFile file = new FormFile(stream, 0, byteArray.Length, "name", "profileImage");
            return file;
        }
    }
}
