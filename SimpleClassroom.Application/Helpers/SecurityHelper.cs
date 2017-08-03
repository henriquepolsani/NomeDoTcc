using SimpleClassroom.Domain.Contracts.Services.Helpers;
using System;
using System.Security.Cryptography;
using System.Text;

namespace SimpleClassroom.Application.Helpers
{
    public class SecurityHelper : ISecurityHelper
    {
        public string GenerateMD5Hash(string input)
        {
            var md5 = new MD5CryptoServiceProvider();

            byte[] originalBytes = ASCIIEncoding.Default.GetBytes(input);
            byte[] encodeBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodeBytes).Replace("-", "");
        }
    }
}
