using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DotNetTrainingTest.ConsoleApp.Model;

namespace DotNetTrainingTest.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
       public readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "TestDb",
            UserID = "sa",
            Password = "sa@123"

        };
        public void Read()
        {

            string query = @"SELECT [BlogId],
                            [BlogTitle],
                            [BlogAuthor],
                            [BlogContent]
                           FROM [dbo].[Tb_Blog]";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();

            foreach (BlogModel item in lst)
            {
                Console.WriteLine("Title.." + item.BlogTitle);
                Console.WriteLine("Author.." + item.BlogAuthor);
                Console.WriteLine("Cotent.." + item.BlogContent);
            }

        }

        public void Edit(int id)
        {
           
            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Tb_Blog] WHERE BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new { BlogId = id }).FirstOrDefault();
            if (item is null)
                Console.WriteLine("No Data Found.");
            else
            {
                Console.WriteLine("Title.." + item.BlogTitle);
                Console.WriteLine("Author.." + item.BlogAuthor);
                Console.WriteLine("Content.." + item.BlogContent);
            }
        }

        public void Create(string title, string author, string content)
        {
            string query = @"INSERT INTO [dbo].[Tb_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result =  db.Execute(query , blog);

            string message = result > 0 ? "Saving Successful." : "Saving Fail.";
            Console.WriteLine(message);
        }
        public void Update(int id, string title, string author, string content)
        {

            string query = @"UPDATE [dbo].[Tb_Blog]
                          SET [BlogTitle] = @BlogTitle 
                         ,[BlogAuthor] = @BlogAuthor
                         ,[BlogContent] = @BlogContent
                          WHERE BlogId = @BlogId";

            BlogModel blog = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor=author,
                BlogContent = content
            };
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Updating Success." : "Updating Fail.";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {

            string query = @"DELETE FROM [dbo].[Tb_Blog] WHERE BlogId = @BlogId";

            BlogModel blog = new BlogModel()
            {
                BlogId = id
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query , blog);

            string message = result > 0 ? "Deleting Success." : "Deleting Fail.";
            Console.WriteLine(message);

        }


    }
}
