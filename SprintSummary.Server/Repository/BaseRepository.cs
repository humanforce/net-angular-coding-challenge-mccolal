using AngularApp3.Server.Helpers;
using System.IO;

namespace SprintSummary.server.Repository
{
    public class BaseRepository
    {
        
        private string _path;

        public BaseRepository(string path)
        {
            _path = path;
        }

        public string Read()
        {
            using StreamReader reader = new(_path);
            string data = reader.ReadToEnd();
            return data;
        }
    }
}
