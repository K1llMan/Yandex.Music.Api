using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Yandex.Music.Api.Common
{
    /// <summary>
    /// Класс для шифровки потом
    /// </summary>
    public class Encryptor
    {
        #region Поля

        private MD5 md5;

        private string IV = "encryption";
        private Rijndael rijAlg;

        private byte[] keyHash;
        private byte[] IVHash;

        #endregion Поля

        #region Вспомогательные функции

        private byte[] GetHash(string value)
        {
            return md5.ComputeHash(Encoding.UTF8.GetBytes(value));
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public Encryptor(string key)
        {
            md5 = MD5.Create();

            rijAlg = Rijndael.Create();
            rijAlg.BlockSize = 128;
            rijAlg.Padding = PaddingMode.PKCS7;

            keyHash = GetHash(key);
            IVHash = GetHash(IV);
        }

        public byte[] Encrypt(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream()) 
                using (CryptoStream csEncrypt = new CryptoStream(ms, rijAlg.CreateEncryptor(keyHash, IVHash), CryptoStreamMode.Write)) {
                    csEncrypt.Write(data, 0, data.Length);

                    if (!csEncrypt.HasFlushedFinalBlock)
                        csEncrypt.FlushFinalBlock();

                    return ms.ToArray();
                }
        }

        public byte[] Decrypt(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream())
                using (CryptoStream csDecrypt = new CryptoStream(ms, rijAlg.CreateDecryptor(keyHash, IVHash), CryptoStreamMode.Write)) {
                    csDecrypt.Write(data, 0, data.Length);

                    if (!csDecrypt.HasFlushedFinalBlock)
                        csDecrypt.FlushFinalBlock();

                    return ms.ToArray();
                }
        }

        #endregion Основные функции
    }
}
