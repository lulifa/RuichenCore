using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RuichenCore.Common
{
    public static class LoginManager
    {
        private static readonly string DecryptSecretKey = "MIICXAIBAAKBgQDKOJybB/0CQYeStbZZmr1SfgAKUou3cV7jT9abur5lin6Ct27CZe7XzmEYJu8fYnVmTYK1o6sioWP3Ji1ueEohDo/bzizFZDoxHp2pbKTefpc0HK6A+bLXo13xdBd+4up88Gz4YQmfHLbPhY+83z78stU/91ap10o/3XPfQ4xHBwIDAQABAoGAEMX5V3KmLdW5pRWldnE7WuhQoIqQRDsHH9uzdV9cA5glPjpw2XcTBJt9uj8gfn3wNvge62oT+99fJ1TnV85qd4W5HM0u2pGmMbjgy2GxphJzJvdupqbkM+Ne/6k+je/+HAUHMSKZMRJLMz+lxi0wEY6Y4JwcaEcvmoPj/a9NQoECQQDn8TpBSoFHEQxUv/ubW2sWJLLKRKyhKbLLHhAyHxnZyMjlr8QkBdmCIZ3AfkF0rzUy2kOheRGpFtdT4G+PH6OXAkEA3zIyfXQUPkdQKH/bSWu+8PXsYomRBhT5ifA+TYuNmr4Nj2Qwky4r6kCKvIsV7oGFocXm0HL04SlYLDZ+bmYmEQJBAMKvpvha83yVgMY6h5V1/MMPdst1LXnxqFP6HhoUJPy7HnY9POQHzPUABowm7gZlcsAGmTIWj45gz8ll3/5Azm0CQEXHQsO367BAyU2wE1WT6uEYcWupCH73RcCbLE9ABuhO7JxcvVb2Q2J8BSPG8/dZ5PZbkbqvheFy9I72BnbrVpECQFD5FCnV3uaffkOxVwxToMdTVP2r70WfYjCrqR/Gp76IAlVTmfUxox3CdVuAAk6n1Jvb5Wpc4nJ40999wqkeHNE=";
        private static readonly string EncryptSecretKey ="MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDKOJybB/0CQYeStbZZmr1SfgAKUou3cV7jT9abur5lin6Ct27CZe7XzmEYJu8fYnVmTYK1o6sioWP3Ji1ueEohDo/bzizFZDoxHp2pbKTefpc0HK6A+bLXo13xdBd+4up88Gz4YQmfHLbPhY+83z78stU/91ap10o/3XPfQ4xHBwIDAQAB";
        private static RSACryptoServiceProvider DecryptProvider => CreateRsaProviderFromDecrypt(DecryptSecretKey);
        private static RSACryptoServiceProvider EncryptProvider => CreateRsaProviderFromEncrypt(DecryptSecretKey);
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public static string Decrypt(string cipherText)
        {
            return Encoding.UTF8.GetString(DecryptProvider.Decrypt(Convert.FromBase64String(cipherText), false));
        }

        /// <summary>
        /// 加密
        /// </summary>
        public static string Encrypt(string text)
        {
            return Convert.ToBase64String(EncryptProvider.Encrypt(Encoding.UTF8.GetBytes(text), false));
        }

        /// <summary>
        /// 将openSSl的密钥转换成C#的RSA密钥
        /// </summary>
        private static RSACryptoServiceProvider CreateRsaProviderFromDecrypt(string privateKey)
        {
            var privateKeyBits = Convert.FromBase64String(privateKey);

            var rsa = new RSACryptoServiceProvider();
            var rsaParams = default(RSAParameters);

            using (BinaryReader reader = new BinaryReader(new MemoryStream(privateKeyBits)))
            {
                byte bt = 0;
                ushort twobytes = 0;
                twobytes = reader.ReadUInt16();
                if (twobytes == 0x8130)
                    reader.ReadByte();
                else if (twobytes == 0x8230)
                    reader.ReadInt16();
                else
                    throw new Exception("Unexpected value read binr.ReadUInt16()");

                twobytes = reader.ReadUInt16();
                if (twobytes != 0x0102)
                    throw new Exception("Unexpected version");

                bt = reader.ReadByte();
                if (bt != 0x00)
                    throw new Exception("Unexpected value read binr.ReadByte()");

                rsaParams.Modulus = reader.ReadBytes(GetIntegerSize(reader));
                rsaParams.Exponent = reader.ReadBytes(GetIntegerSize(reader));
                rsaParams.D = reader.ReadBytes(GetIntegerSize(reader));
                rsaParams.P = reader.ReadBytes(GetIntegerSize(reader));
                rsaParams.Q = reader.ReadBytes(GetIntegerSize(reader));
                rsaParams.DP = reader.ReadBytes(GetIntegerSize(reader));
                rsaParams.DQ = reader.ReadBytes(GetIntegerSize(reader));
                rsaParams.InverseQ = reader.ReadBytes(GetIntegerSize(reader));
            }

            rsa.ImportParameters(rsaParams);
            return rsa;
        }

        /// <summary>
        /// 将openSSl的密钥转换成C#的RSA密钥
        /// </summary>
        private static RSACryptoServiceProvider CreateRsaProviderFromEncrypt(string publicKeyString)
        {
            // encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
            byte[] SeqOID = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
            byte[] x509key;
            byte[] seq = new byte[15];
            int x509size;

            x509key = Convert.FromBase64String(publicKeyString);
            x509size = x509key.Length;

            // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
            using (MemoryStream mem = new MemoryStream(x509key))
            {
                using (BinaryReader binr = new BinaryReader(mem))  //wrap Memory Stream with BinaryReader for easy reading
                {
                    byte bt = 0;
                    ushort twobytes = 0;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return null;

                    seq = binr.ReadBytes(15);       //read the Sequence OID
                    if (!CompareBytearrays(seq, SeqOID))    //make sure Sequence for OID is correct
                        return null;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8103) //data read as little endian order (actual data order for Bit String is 03 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8203)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return null;

                    bt = binr.ReadByte();
                    if (bt != 0x00)     //expect null byte next
                        return null;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return null;

                    twobytes = binr.ReadUInt16();
                    byte lowbyte = 0x00;
                    byte highbyte = 0x00;

                    if (twobytes == 0x8102) //data read as little endian order (actual data order for Integer is 02 81)
                        lowbyte = binr.ReadByte();  // read next bytes which is bytes in modulus
                    else if (twobytes == 0x8202)
                    {
                        highbyte = binr.ReadByte(); //advance 2 bytes
                        lowbyte = binr.ReadByte();
                    }
                    else
                        return null;
                    byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };   //reverse byte order since asn.1 key uses big endian order
                    int modsize = BitConverter.ToInt32(modint, 0);

                    int firstbyte = binr.PeekChar();
                    if (firstbyte == 0x00)
                    {   //if first byte (highest order) of modulus is zero, don't include it
                        binr.ReadByte();    //skip this null byte
                        modsize -= 1;   //reduce modulus buffer size by 1
                    }

                    byte[] modulus = binr.ReadBytes(modsize);   //read the modulus bytes

                    if (binr.ReadByte() != 0x02)            //expect an Integer for the exponent data
                        return null;
                    int expbytes = (int)binr.ReadByte();        // should only need one byte for actual exponent data (for all useful values)
                    byte[] exponent = binr.ReadBytes(expbytes);

                    // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                    RSAParameters rsaKeyInfo = new RSAParameters
                    {
                        Modulus = modulus,
                        Exponent = exponent,
                    };
                    rsa.ImportParameters(rsaKeyInfo);

                    return rsa;
                }
            }
        }

        private static int GetIntegerSize(BinaryReader binr)
        {
            byte bt = 0;
            byte lowbyte = 0x00;
            byte highbyte = 0x00;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02)
                return 0;
            bt = binr.ReadByte();

            if (bt == 0x81)
                count = binr.ReadByte();
            else
                if (bt == 0x82)
            {
                highbyte = binr.ReadByte();
                lowbyte = binr.ReadByte();
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt;
            }

            while (binr.ReadByte() == 0x00)
            {
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);
            return count;
        }
        private static bool CompareBytearrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;
            int i = 0;
            foreach (byte c in a)
            {
                if (c != b[i])
                    return false;
                i++;
            }
            return true;
        }

    }
}
