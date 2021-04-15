using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleApi.Data;
using SimpleApi.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {

        private INewsService _service;

        public StoriesController(INewsService nService)
        {
            _service = nService;
        }

        [HttpGet]
        [Route("topTenStories")]
        public async Task<IEnumerable<Story>> GetStories()
        {
            var result = await _service.GetStories();
            return result;
        }

        [HttpGet]
        [Route("top10ids")]
        public async Task<ActionResult<IEnumerable<int>>> GetTopIds()
        {
            return StatusCode(200, await _service.GetTopIds());

        }

        [HttpGet]
        [Route("getOne/{id}")]
        public async Task<Story> GetOne(int id)
        {
            var res = await _service.GetSingleStorie(id);

            return res;
        }

    }
}
