using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleApi.Data;
using System.Collections.Generic;
using System.IO;

namespace SimpleApiTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDtoMapping()
        {
            var kids = new List<int>() { 2, 3, 7 };
            var dto = new StoryDto() { By="test", Id=122, Score=1, Time = 1570887781, Descendants=123, Title="test", Type="Post", Url="test url", Kids = kids};
            var story = StoryDto.ConvertToStory(dto);
            Assert.AreEqual(story.PostedBy, dto.By);
        }

        [TestMethod]
        public void TestDtoMappingWithNull()
        {
            var dto = new StoryDto() { By = "test", Id = 122, Score = 1, Time = 1570887781, Descendants = 123, Title = "test", Type = "Post", Url = "test url", Kids = null };
            var story = StoryDto.ConvertToStory(dto);
            Assert.AreEqual(story.CommentCount, 0);
        }
    }
}
