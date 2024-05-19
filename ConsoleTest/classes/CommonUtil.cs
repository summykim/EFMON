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
                    string encrypted = Encoding.UTF8.GetString(encryptedData);


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

            string  authKey= Encrypt(authKeyString);
            Console.WriteLine(authKey);

            return authKey;
        }

        static string Encrypt(string text)
        {
            const int PROVIDER_RSA_FULL = 1;
            const string CONTAINER_NAME = "Tracker";

            CspParameters cspParams;
            cspParams = new CspParameters(PROVIDER_RSA_FULL);
            cspParams.KeyContainerName = CONTAINER_NAME;

            RSACryptoServiceProvider rsa1 = new RSACryptoServiceProvider(512, cspParams);
            string publicKey = ConfigurationManager.AppSettings.Get("rsaPubKey");
            RSAParameters rsaParameters = GetRSAParametersFromKey(publicKey);
            rsa1.ImportParameters(rsaParameters);

            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            byte[] encryptedOutput = rsa1.Encrypt(textBytes, RSAEncryptionPadding.Pkcs1);
            string outputB64 = Convert.ToBase64String(encryptedOutput);

            return outputB64;
        }

    }
}
