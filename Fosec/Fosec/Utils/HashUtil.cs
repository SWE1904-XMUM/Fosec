using System.Security.Cryptography;
using System.Text;

namespace Fosec.Utils
{
    public static class HashUtil
    {
        public static byte[] GetHashedBytesByInput(string input)
        {
            //return hashed input in bytes
            return new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes(input));
        }

        public static string GetHashedStringByInput(string input)
        {
            //return hashed input in string
            return StringUtil.ByteArrayToString(GetHashedBytesByInput(input));
        }

        public static bool CompareHash(string hashedStr, string strToCompare)
        {
            return hashedStr == GetHashedStringByInput(strToCompare);
        }
    }
}