using Newtonsoft.Json;
using SimpleApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleApi.Services
{
    public class NewsService : INewsService
    {
        private HttpClient _client;
        public NewsService()
        {
          _client = new HttpClient();
        }
        public async Task<Story> GetSingleStorie(int id)
        {
            var url = $"https://hacker-news.firebaseio.com/v0/item/{id}.json";
            HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<StoryDto>(json);
                var story = StoryDto.ConvertToStory(dto);
                return story;
                
            }
            return new Story();
        }

        public async Task<IEnumerable<Story>> GetStories()
        {
            var stories = new List<Story>();
            var ids = await GetTopIds();
            try
            {
                foreach (int id in ids)
                {

                    var story = await GetSingleStorie(id);
                    stories.Add(story);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return stories;
        }

        public async Task<IEnumerable<int>> GetTopIds()
        {
            HttpResponseMessage response = await _client.GetAsync("https://hacker-news.firebaseio.com/v0/topstories.json");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<int>>(json);
                var res = list.Take(20).ToList();
                return res;
            }
            return new List<int>();

        }
    }
}
