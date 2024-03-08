using DotNetTrainingTest.HWArtApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DotNetTrainingTest.HWArtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtController : ControllerBase
    {
        private readonly string _url = "https://burma-project-ideas.vercel.app/art-gallery";

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            HttpClient _httpClient = new HttpClient();
            var response = await _httpClient.GetAsync(_url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<ArtDataModel> data = JsonConvert.DeserializeObject<List<ArtDataModel>>(json)!;
                List<ArtViewModel> lst = data.Select(x => new ArtViewModel
                {
                    Id = x.ArtId,
                    Name = x.ArtName,
                    PictureUrl = $"https://burma-project-ideas.vercel.app/{x.ArtImageUrl}"

                }).ToList();
                return Ok(lst);

            } else return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            HttpClient _httpClient = new HttpClient();
            var response = await _httpClient.GetAsync($"{_url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync() ;
                ArtByIdDataModel data = JsonConvert.DeserializeObject<ArtByIdDataModel>(json) !;
                var item = new ArtByIdViewModel()
                {
                    ArtistId = data.Artist.ArtistId,
                    ArtistName = data.Artist.ArtistName,
                    FaceBookAccount = data.Artist.Social[0].Link,
                    ArtList = data.Arts
                };
                return Ok(item);               
            }else return BadRequest();
            
        }

    }

}
