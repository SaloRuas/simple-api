using SimpleApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleApi.Services
{
    public interface INewsService
    {
        public  Task<IEnumerable<Story>> GetStories();

        public Task<IEnumerable<int>> GetTopIds();

        public Task<Story> GetSingleStorie(int id);
    }
}
