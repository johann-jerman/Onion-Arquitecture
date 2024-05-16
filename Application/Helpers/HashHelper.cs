using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class HashHelper
    {
        public static string Hash(string toHash) 
        {
            SHA256 encoderSHA256 = SHA256.Create();

            ASCIIEncoding encoding = new ASCIIEncoding();

            byte[] stream = null;

            StringBuilder stringBuilder = new StringBuilder();

            stream = encoderSHA256.ComputeHash(encoding.GetBytes(toHash));

            for (int i = 0; i < stream.Length; i++)
            {
                stringBuilder.AppendFormat("{0:x2}", stream[i]);
            }

            return stringBuilder.ToString();
        }

        public static bool VerifyHash(string inputString, string hash)
        {
            // Convert the input string to a byte array using ASCII encoding
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] inputBytes = encoding.GetBytes(inputString);

            // Create a SHA256 encoder for hashing
            SHA256 encoderSHA256 = SHA256.Create();

            // Compute the hash of the input string
            byte[] computedHash = encoderSHA256.ComputeHash(inputBytes);

            // Convert the computed hash to a lowercase hexadecimal string
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < computedHash.Length; i++)
            {
                stringBuilder.AppendFormat("{0:x2}", computedHash[i]);
            }
            string computedHashString = stringBuilder.ToString().ToLower();

            // Compare the computed hash with the provided hash
            return computedHashString.Equals(hash.ToLower());
        }
    }
}
