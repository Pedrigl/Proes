using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;

namespace ProesBack.Infrastructure.Data.Common
{
    public static class Settings
    {
        public static byte[] GetKey()
        {
            return Encoding.ASCII.GetBytes(Convert.ToBase64String(Guid.NewGuid()
            .ToByteArray())
            .Replace("=", "")
            .Replace("+", ""));

        }
         
    }
}
