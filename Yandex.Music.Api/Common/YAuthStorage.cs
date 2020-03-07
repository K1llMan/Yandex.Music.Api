using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using Yandex.Music.Api.Requests;

namespace Yandex.Music.Api.Common
{
    /// <summary>
    /// Хранилище данных пользователя
    /// </summary>
    public class YAuthStorage
    {
        #region Свойства

        public bool IsAuthorized { get; internal set; }

        public HttpContext Context { get; }

        public YUser User { get; set; }

        #endregion Свойства

        public YAuthStorage(string login, string password)
        {
            User = new YUser {
                Login = login,
                Password = password
            };

            Context = new HttpContext();
        }

        public bool Save(string fileName)
        {
            File.Delete(fileName);

            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
                bf.Serialize(fs, Context.Cookies);

            return true;

            /*
            var jsonUser = JsonConvert.SerializeObject(user);

            using (var stream = new FileStream(path, FileMode.OpenOrCreate)) {
                using (var writer = new StreamWriter(stream)) {
                    await writer.WriteAsync(jsonUser);
                }
            }
            */
        }

        public bool Load(string fileName)
        {
            if (!File.Exists(fileName))
                return false;

            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
                Context.Cookies = (CookieContainer) bf.Deserialize(fs);

            return true;

            /*
            var userSource = string.Empty;

            using (var stream = new FileStream(path, FileMode.Open)) {
                using (var reader = new StreamReader(stream)) {
                    userSource = await reader.ReadToEndAsync();
                }
            }

            user = JsonConvert.DeserializeObject<YUser>(userSource);

            return user;
            */
        }
    }
}