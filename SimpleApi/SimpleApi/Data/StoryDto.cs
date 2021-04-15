using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi.Data
{
    public class StoryDto
    {
        public string By { get; set; }
        public int Descendants { get; set; }
        public int Id { get; set; }
        public List<int> Kids { get; set; }
        public int Score { get; set; }
        public long Time { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }

        public static Story ConvertToStory(StoryDto dto)
        {
            var story = new Story();
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(dto.Time).ToLocalTime();
            story.Time = dtDateTime.ToString("yyyy-MM-ddTHH:mm:ss.K");

            story.Title = dto.Title;
            story.PostedBy = dto.By;
            story.Score = dto.Score;
            story.Uri = dto.Url;
            story.CommentCount = dto.Kids == null ? 0 : dto.Kids.Count();
            
            return story;
        }

    }
   
}
