using DotNetTrainingTest.ConsoleApp.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingTest.ConsoleApp.RestClientExamples
{
    public class RestClientExample
    {
        private readonly string _apiUrl = "https://localhost:7267/api/Blog";
        public async Task Run()
        {
            //await Read();
            //await Edit(13);
            //await Edit(20);
            //await Create("title", "author", "content");
            //await Update(17,"title 2", "author 2", "content 2");
            await Delete(17);
        }
        public async Task Read()
        {
            RestRequest request = new RestRequest(_apiUrl , Method.Get);
            RestClient client = new RestClient();
            RestResponse response =await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr =  response.Content!;
                List<BlogModel> list = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
                foreach (BlogModel blog in list)
                {
                    Console.WriteLine(blog.BlogId);
                    Console.WriteLine(blog.BlogTitle);
                    Console.WriteLine(blog.BlogAuthor);
                    Console.WriteLine(blog.BlogContent);
                }
            }
            else
            {
                Console.WriteLine(response.Content);
            }
        }

        public async Task Edit(int id)
        {
            string url = "{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url, Method.Get);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);

            }
            else
            {
                Console.WriteLine(response.Content);
            }
        }
        public async Task Create(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            RestRequest request = new RestRequest(_apiUrl, Method.Post);
            request.AddJsonBody(blog);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);

            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }

        public async Task Update(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string url = "{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url, Method.Put);
            request.AddJsonBody(blog);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {

                Console.WriteLine(response.Content!);

            }
            else
            {
                Console.WriteLine(response.Content);
            }
        }

        public async Task Delete(int id)
        {
            string url = "{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url, Method.Get);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }
    }

}

