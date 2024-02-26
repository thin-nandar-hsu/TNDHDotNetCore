using DotNetTrainingTest.ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingTest.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<BlogModel> lst = db.Blogs.ToList();
            foreach( var items in lst)
            {
                Console.WriteLine(items.BlogId);
                Console.WriteLine(items.BlogTitle);
                Console.WriteLine(items.BlogAuthor);
                Console.WriteLine(items.BlogContent);
            }
        }
        public void Edit(int id)
        {
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.FirstOrDefault(items => items.BlogId == id)!;
            if( item is null)
            {
                Console.WriteLine("No Result Found.");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        public void Create(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            AppDbContext db = new AppDbContext();
            db.Add(blog);
            int result = db.SaveChanges();
            string message = result > 0 ? "Saving Success." : "Saving Fail.";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id)!;
            if(item is null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
            int result = db.SaveChanges();
            string message = result > 0 ? "Updating Success." : "Updating Fail.";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id)!;
            if(item is null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }
            db.Remove(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Deleting Success." : "Deleting Fail.";
            Console.WriteLine(message);
        }
    }
}
