using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;

namespace ConsoleTest.classes
{
   static class CommonUtil
{
        public const bool PKCS1_PADDING = false;
        static string EncryptWithRSA(string dataToEncrypt, string publicKey)
        {
            try
            {

                RSAParameters rsaParameters = GetRSAParametersFromKey(publicKey);

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {

                    rsa.ImportParameters(rsaParameters);
                    
                    byte[] dataBytes = Encoding.UTF8.GetBytes(dataToEncrypt); ;
                    Array.Resize(ref dataBytes, 8);
                    byte[] encryptedData = rsa.Encrypt(dataBytes, false);
                   // string encryptedBase64 = Convert.ToBase64String(encryptedData);
                    string encrypted = byteArrayToHex(encryptedData);
 
                    return encrypted;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Encryption failed: " + ex.Message);
            }

            return "";
        }
        static RSAParameters GetRSAParametersFromKey(string publicKeyValue)
        {
            byte[] modulusBytes = Encoding.UTF8.GetBytes(publicKeyValue);
            Array.Resize(ref modulusBytes, 256);
            byte[] exponentBytes = { 1, 0, 1 };

            RSAParameters rsaParameters = new RSAParameters
            {
                Modulus = modulusBytes,
                Exponent = exponentBytes
            };

            return rsaParameters;
        }

        public static string GetEncryptValue(string targetData)
        {

             string publicKey = ConfigurationManager.AppSettings.Get("rsaPubKey");
            string encrypted = EncryptWithRSA(targetData, publicKey);



            //byte[] encryptedBytes = Convert.FromBase64String(encryptedCreditCard);
            //string decryptedData = Encoding.UTF8.GetString(encryptedBytes);

            return encrypted;
        }
        public static string makeAuthKey()
        {
            string  today= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string authKeyString = "EFORM_" + today;
            Console.WriteLine(authKeyString);

            //string  authKey= Encrypt(authKeyString);
            RSACryptoServiceProvider initialProvider = new RSACryptoServiceProvider(2048);
            string authKey = Encrypt(initialProvider, authKeyString);
            Console.WriteLine("plaintext encrypted to: " + authKey);

            return authKey;
        }

        static string Encrypt(string text)
        {
            const int PROVIDER_RSA_FULL = 1;
            const string CONTAINER_NAME = "Tracker";

            CspParameters cspParams;
            cspParams = new CspParameters(PROVIDER_RSA_FULL);
            cspParams.KeyContainerName = CONTAINER_NAME;

            RSACryptoServiceProvider rsa1 = new RSACryptoServiceProvider(256, cspParams);
            string publicKey = ConfigurationManager.AppSettings.Get("rsaPubKey");
            RSAParameters rsaParameters = GetRSAParametersFromKey(publicKey);
            rsa1.ImportParameters(rsaParameters);

            byte[] certBytes = Encoding.UTF8.GetBytes(publicKey);
            X509Certificate2 cert = new X509Certificate2(certBytes);
            RSACryptoServiceProvider publicKeyProvider =
            (RSACryptoServiceProvider)cert.PublicKey.Key;

            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            byte[] encryptedOutput = publicKeyProvider.Encrypt(textBytes, RSAEncryptionPadding.Pkcs1);
            string outputB64 = byteArrayToHex(encryptedOutput);

            return outputB64;
        }

        public static String byteArrayToHex(byte[] bytearray)
        {
            if (bytearray == null || bytearray.Length == 0)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder(bytearray.Length * 2);
            String hexNumber;
            for (int x = 0; x < bytearray.Length; x++)
            {
                hexNumber = "0" + ToHex(0xff & bytearray[x]);
                sb.Append(hexNumber.Substring(hexNumber.Length - 2));
            }
            return sb.ToString();
        }
        private static string ToHex(this int value)
        {
            return String.Format("0x{0:x}", value);
        }


        public static string Encrypt(
            RSACryptoServiceProvider csp,
            string plaintext
        )
        {
            return byteArrayToHex(
                csp.Encrypt(
                    Encoding.UTF8.GetBytes(plaintext),
                    PKCS1_PADDING
                )
            );
        }
    }
}
