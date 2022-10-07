// See https://aka.ms/new-console-template for more information
using EFSaving.Disconnected;
using Microsoft.EntityFrameworkCore;

BloggingContext dc = new BloggingContext();

//dc.Database.EnsureCreated();

//Blog blog = new Blog();

//blog.Url = "w2";



//blog.Posts.Add(new Post { Content = "p1", Title = "t1" });
//blog.Posts.Add(new Post { Content = "p2", Title = "t2" });

//dc.Blogs.Add(blog);


var b1 = dc.Blogs
    .Include(c => c.Posts)
    .AsNoTracking()
    .First();

var p1 = b1.Posts.Last();


p1.IsDeleted = true;


SaveAnnotatedGraph(dc, p1);

void SaveAnnotatedGraph(DbContext context, object rootEntity)
{
    context.ChangeTracker.TrackGraph(
        rootEntity,
        n =>
        {
            var entity = (EntityBase)n.Entry.Entity;
            n.Entry.State = entity.IsNew
                ? EntityState.Added
                : entity.IsChanged
                    ? EntityState.Modified
                    : entity.IsDeleted
                        ? EntityState.Deleted
                        : EntityState.Unchanged;
        });

    context.SaveChanges();
}


//var ddd = "";
