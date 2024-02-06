using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingTest.ConsoleApp.ADODotNetExamples
{
    public class ADODotNetExample
    {
        public void Read()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sa@123";
            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Tb_Blog]";
            SqlConnection _sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            _sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, _sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            _sqlConnection.Close();
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Title.." + dr["BlogTitle"]);
                Console.WriteLine("Author.." + dr["BlogAuthor"]);
                Console.WriteLine("Content.." + dr["BlogContent"]);
            }
        }

        public void Edit(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sa@123";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Tb_Blog] WHERE BlogId = @BlogId";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlConnection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("NoDataFound.");
                return;
            }
            DataRow dr = dt.Rows[0];
            Console.WriteLine("Title.." + dr["BlogTitle"]);
            Console.WriteLine("Author.." + dr["BlogAuthor"]);
            Console.WriteLine("Content.." + dr["BlogContent"]);

        }

        public void Create(string title, string author, string content)
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = ".";
            stringBuilder.InitialCatalog = "TestDb";
            stringBuilder.UserID = "sa";
            stringBuilder.Password = "sa@123";
            SqlConnection _sqlConnection = new SqlConnection(stringBuilder.ConnectionString);
            _sqlConnection.Open();
            string query = @"INSERT INTO [dbo].[Tb_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            SqlCommand cmd = new SqlCommand(query, _sqlConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            _sqlConnection.Close();
            string message = result > 0 ? "Saving Successful." : "Saving Fail.";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = ".";
            connectionStringBuilder.InitialCatalog = "TestDb";
            connectionStringBuilder.UserID = "sa";
            connectionStringBuilder.Password = "sa@123";
            SqlConnection sqlConnection = new SqlConnection(connectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = @"UPDATE [dbo].[Tb_Blog]
   SET [BlogTitle] = @BlogTitle 
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();

            sqlConnection.Close();

            string message = result > 0 ? "Updating Success." : "Updating Fail.";

            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = ".";
            connectionStringBuilder.InitialCatalog = "TestDb";
            connectionStringBuilder.UserID = "sa";
            connectionStringBuilder.Password = "sa@123";
            SqlConnection sqlConnection = new SqlConnection(connectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = @"DELETE FROM [dbo].[Tb_Blog] WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            string message = result > 0 ? "Deleting Success." : "Deleting Fail.";
            Console.WriteLine(message);

        }
    }
}
