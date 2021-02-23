using System;
using System.Collections.Generic;
using System.Text;

namespace Nutritionist.Core.Helper
{
    public static class StaticMethods
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
    }
}
