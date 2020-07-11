using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

using Yandex.Music.Api.Requests;

namespace Yandex.Music.Api.Common
{
    /// <summary>
    /// Типы шифрования
    /// </summary>
    public enum YAuthStorageEncryption
    {
        /// <summary>
        /// Без шифрования
        /// </summary>
        None,
        /// <summary>
        /// Rijndael
        /// </summary>
        Rijndael
    }

    /// <summary>
    /// Хранилище данных пользователя
    /// </summary>
    public class YAuthStorage
    {
        #region Поля

        private readonly YAuthStorageEncryption encryption;
        private readonly Encryptor encryptor;

        #endregion Поля

        #region Свойства

        /// <summary>
        /// Флаг авторизации
        /// </summary>
        public bool IsAuthorized { get; internal set; }

        /// <summary>
        /// Http-контекст
        /// </summary>
        public HttpContext Context { get; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public YUser User { get; set; }

        /// <summary>
        /// Токен авторизации
        /// </summary>
        public string Token { get; internal set; }

        #endregion Свойства

        #region Вспомогательные функции

        #endregion Вспомогательные функции

        #region Основные функции

        public void SetHeaders(HttpWebRequest request)
        {
            request.Headers.Add("Authorization", $"OAuth {Token}");
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="usedEncryption">Тип шифрования куков</param>
        public YAuthStorage(YAuthStorageEncryption usedEncryption = YAuthStorageEncryption.None)
        {
            User = new YUser();

            Context = new HttpContext();

            // Шифрование
            encryptor = new Encryptor($"");
            encryption = usedEncryption;
        }

        /// <summary>
        /// Установка прокси для пользователия
        /// </summary>
        /// <param name="proxy">Прокси</param>
        public void SetProxy(IWebProxy proxy)
        {
            Context.WebProxy = proxy;
        }

        /// <summary>
        /// Сохранение куков
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns></returns>
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

        /// <summary>
        /// Загрузка куков
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns></returns>
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