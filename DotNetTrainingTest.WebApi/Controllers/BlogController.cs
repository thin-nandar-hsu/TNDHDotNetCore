using DotNetTrainingTest.WebApi.EFCoreExamples;
using DotNetTrainingTest.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BlogController()
        {
            _db = new AppDbContext();
        }
        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogModel> lst = _db.Blogs.OrderByDescending(x => x.BlogId).ToList();
            return Ok(lst);
        }


        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            _db.Add(blog);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving Successful" : "Saving Fail";
            return Ok(message);
        }

        [HttpGet("{id}")]
        public IActionResult EditBlog(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No Data Found.");
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel updateBlog)
        {
            BlogModel item = _db.Blogs.FirstOrDefault(x => x.BlogId == id)!;
            if (item is null)
                return NotFound("No Data Found");

            item.BlogTitle = updateBlog.BlogTitle;
            item.BlogAuthor = updateBlog.BlogAuthor;
            item.BlogContent = updateBlog.BlogContent;
            int result = _db.SaveChanges();
            string message = result > 0 ? "Updating Success." : "Updating Fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
                return NotFound("No Data Found.");

            _db.Remove(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Deleting Success." : "Deleting Falil.";
            return Ok(message);
        }

    }
}
