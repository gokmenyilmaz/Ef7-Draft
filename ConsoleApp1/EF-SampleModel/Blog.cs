using System.Collections.Generic;

namespace EFSaving.Disconnected;

public class Blog : EntityBase
{
    public int BlogId { get; set; }
    public string Url { get; set; }

    public Blog()
    {
        Posts = new List<Post>();
    }

    public List<Post> Posts { get; set; }
}