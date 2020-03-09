using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

using Yandex.Music.Api.Requests;

namespace Yandex.Music.Api.Common
{
    public enum YAuthStorageEncryption
    {
        None,
        Rijndael
    }

    /// <summary>
    ///     Хранилище данных пользователя
    /// </summary>
    public class YAuthStorage
    {
        #region Поля

        private readonly YAuthStorageEncryption encryption;
        private readonly Encryptor encryptor;

        #endregion Поля

        #region Свойства

        public bool IsAuthorized { get; internal set; }

        public HttpContext Context { get; }

        public YUser User { get; set; }

        #endregion Свойства

        #region Вспомогательные функции

        #endregion Вспомогательные функции

        #region Основные функции

        public YAuthStorage(string login, string password, YAuthStorageEncryption usedEncryption = YAuthStorageEncryption.None)
        {
            User = new YUser {
                Login = login,
                Password = password
            };

            Context = new HttpContext();

            // Шифрование
            encryptor = new Encryptor($"{User.Login}|{User.Password}");
            encryption = usedEncryption;
        }

        public bool Save(string fileName)
        {
            try {
                File.Delete(fileName);

                byte[] bytes;
                using (var ms = new MemoryStream()) {
                    var bf = new BinaryFormatter();
                    bf.Serialize(ms, Context.Cookies);

                    bytes = ms.ToArray();
                }

                switch (encryption) {
                    case YAuthStorageEncryption.Rijndael:
                    {
                        bytes = encryptor.Encrypt(bytes);
                        break;
                    }
                }

                using (var fs = new FileStream(fileName, FileMode.Create)) {
                    fs.Write(bytes, 0, bytes.Length);
                }

                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool Load(string fileName)
        {
            try {
                if (!File.Exists(fileName))
                    return false;

                byte[] bytes;

                using (var fs = new FileStream(fileName, FileMode.Open)) {
                    bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                }

                switch (encryption) {
                    case YAuthStorageEncryption.Rijndael:
                    {
                        bytes = encryptor.Decrypt(bytes);
                        break;
                    }
                }

                using (var ms = new MemoryStream(bytes)) {
                    var bf = new BinaryFormatter();
                    Context.Cookies = (CookieContainer) bf.Deserialize(ms);
                }

                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return false;
            }
        }

        #endregion Основные функции
    }
}