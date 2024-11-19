using MongoDBDL;
using MongoDBDL.Model;

namespace ConsoleAppTestMongoDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = @"mongodb://localhost:27017/";
            List<Comment> comments = new List<Comment>()
            {
                new Comment("luc","top",new DateTime(2024,8,11),new List<string>(){"HoGent","NoSQL"}),
                new Comment("pol","great tutorial, loving IT",new DateTime(2024,11,11),new List<string>(){"IT","NoSQL","c#"}),
                new Comment("inga","fun",new DateTime(2024,8,11),new List<string>(){"fun","NoSQL"})
            };
            Post post1 = new Post("MongoDB tutorial", "jos", "Learn about MongoDB document store", new DateTime(2024, 1, 11), comments);
            comments = new List<Comment>()
            {
                new Comment("luc","top",new DateTime(2024,8,11),new List<string>(){"HoGent","REST"}),
                new Comment("pol","great tutorial, loving IT",new DateTime(2024,7,11),new List<string>(){"IT","ASP.NET","c#"}),
                new Comment("inga","relaxing and fun",new DateTime(2024,8,11),new List<string>(){"fun","REST"})
            };
            Post post2 = new Post("ASP.NET tutorial", "jos", "Learn to build a REST service", new DateTime(2024, 7, 11), comments);

            PostDAO dao=new PostDAO(connectionString);
            //dao.WritePosts(new List<Post>() { post1, post2 });
            //var p = dao.FilterPostByAuthor("jos");
            //var p2 = dao.FindPostFromAuthor("jos");
            var x = dao.FindPostByAuthorAndDate("jos", new DateTime(2024, 2, 10), DateTime.Now);
            //var y=dao.FindPostFromAuthorAndDate("jos", new DateTime(2024, 2, 10), DateTime.Now);
            //var z = dao.FindPostWithTag("HoGent");
            //var q = dao.FindPostWithAllTags(new List<string>() { "REST", "fun" });
            var post = x.First();
            post.Author = "Julie";
            post.Comments.Add(new Comment("lucia", "toppy", new DateTime(2024, 8, 11), new List<string>() { "HoGent", "REST","Extra" }));
            dao.UpdateCompleteObject(post);
        }
    }
}
