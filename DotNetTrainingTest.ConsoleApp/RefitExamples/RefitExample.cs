using DotNetTrainingTest.ConsoleApp.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingTest.ConsoleApp.RefitExamples
{
    public class RefitExample
    {
        private readonly IBlogApi _refitApi = RestService.For<IBlogApi>("https://localhost:7267");
        public async Task Run()
        {
            //await Read();
            //await Edit(1);
            //await Edit(22);
            //await Create("title test", "author test ", "content test");
            await Update(11,"title 2", "author 2", "content 2");
        }

        private async Task Read()
        {
            var list = await _refitApi.GetBlogs();
            foreach (BlogModel blog in list)
            {
                Console.WriteLine(blog.BlogId);
                Console.WriteLine(blog.BlogTitle);
                Console.WriteLine(blog.BlogAuthor);
                Console.WriteLine(blog.BlogContent);
            }

        }

        private async Task Edit(int id)
        {
            try
            {
                var item = await _refitApi.GetBlog(id);
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);

            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task Create(string title, string author, string content)
        {
           
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };

                string message = await _refitApi.CreateBlog(blog);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task Update(int id, string title, string author, string content)
        {
           
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };
                string message = await _refitApi.UpdateBlog(id, blog);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                string message = await _refitApi.DeleteBlog(id);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
