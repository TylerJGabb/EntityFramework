using MigrationDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*This example was created via the tutorial at
 * https://msdn.microsoft.com/en-us/library/jj591621(v=vs.113).aspx
 * it covers
 *  1) creating database from code
 *  2) creating migrations and migrating the database to reflect changes made to the object
 *      or newly added objects
 *  3) setting the current database to targeted migrations
 *  4) generating SQL scripts that generate schema based on what we have done
 *  
 *  Create the model
 *  Create instance of context and add blog, then save changes
 *      observe that the database has been created locally for you 
 *  
 *  Add new property to Blog string Url {get;set}
 *      trying to run the code at this point leads to exception, because model has 
 *      changed and database does not reflect said change
 *      
 *  Enable-Migrations (PM console command)
 *      this command creates two files
 *          1) Configuration.cs
 *              defines how migrations behave
 *          2) initial_Migration.cs
 *              contains the code that is executed to apply/rollback the migration
 *              new migration_1234.cs files will be created to rollback/apply future migrations
 *  
 *  Add-Migration (PM console command)
 *      scaffolds the next migration.cs file based on changed made to the model
 *      since last migration
 *      https://channel9.msdn.com/blogs/ef/migrations-under-the-hood
 *      
 *  Update-Database
 *      applies the changes made in the most recent migration to the database
 *      data may be lost here, so you are able to alter the migration before
 *      you call Update-Database
 *      
 *  
 *  
 */

namespace MigrationsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AddNewPostToBlog(1);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void AddOneBlog(string name)
        {
            using (var db = new BlogContext())
            {
                db.Blogs.Add(new Blog { Name = name });
                db.SaveChanges();

                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(blog.Name);
                }
            }
        }

        static void AddNewPostToBlog(int blogId)
        {
            using (var context = new BlogContext())
            {
                var blog = 
                    (from d in context.Blogs where d.BlogId == blogId select d)
                    .Single();

                blog.Posts.Add(new Post
                {
                    Title = "This is another title",
                    Content = "This is some other content"
                    //BlogId = blogId
                });
                context.SaveChanges();

            }
        }
    }
}
