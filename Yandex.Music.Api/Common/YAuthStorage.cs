
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Yandex.Music.Api.Requests;

namespace Yandex.Music.Api.Common
{
    public class YAuthStorage
    {
        private string _filePath;
        
        public YAuthStorage(string filePath)
        {
            _filePath = filePath;
        }
        
        public async Task SaveAsync(YUser user)
        {
            File.Delete(_filePath);

            var jsonUser = JsonConvert.SerializeObject(user);

            using (var stream = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(stream))
                {
                    await writer.WriteAsync(jsonUser);
                }
            }
        }

        public async Task<YUser> LoadAsync()
        {
            var user = default(YUser);

            if (!File.Exists(_filePath))
            {
                return user;
            }

            var userSource = string.Empty;

            using (var stream = new FileStream(_filePath, FileMode.Open))
            {
                using (var reader = new StreamReader(stream))
                {
                    userSource = await reader.ReadToEndAsync();
                }
            }

            user = JsonConvert.DeserializeObject<YUser>(userSource);

            return user;
        }
    }
}