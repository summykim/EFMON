using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace EFORMWIN.classes
{
   static class CommonUtil
{
        public static String getLocalIpAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                Console.WriteLine("No Network Available");
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            IPAddress ippaddress =
                host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            Console.WriteLine(ippaddress);
            return ippaddress.ToString();

        }
        public static string RSAEncrypt(string getValue, string pubKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            RSAParameters rsaParameters = GetRSAParametersFromKey(pubKey);
            rsa.ImportParameters(rsaParameters);

            //암호화할 문자열을 UFT8인코딩
            byte[] inbuf = (new UTF8Encoding()).GetBytes(getValue);

            //암호화
            byte[] encbuf = rsa.Encrypt(inbuf, false);

            //암호화된 문자열 Base64인코딩
            return System.Convert.ToBase64String(encbuf);
        }

        // RSA 복호화
        public static string RSADecrypt(string getValue, string priKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            RSAParameters rsaParameters = GetRSAParametersFromKey(priKey);
            rsa.ImportParameters(rsaParameters);

            //sValue문자열을 바이트배열로 변환
            byte[] srcbuf = System.Convert.FromBase64String(getValue);

            //바이트배열 복호화
            byte[] decbuf = rsa.Decrypt(srcbuf, false);

            //복호화 바이트배열을 문자열로 변환
            string sDec = (new UTF8Encoding()).GetString(decbuf, 0, decbuf.Length);
            return sDec;

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

        public static string makeAuthData(string rsaPubKey)
        {
            string  today= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string authKeyString = "EFORM_" + today;
            Console.WriteLine(authKeyString);

            string  authKey= RSAEncrypt(authKeyString, rsaPubKey);

            return authKey;
        }

    }
}
