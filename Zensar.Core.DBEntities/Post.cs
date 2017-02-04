using System;

namespace Zensar.Core.DBEntities
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Timestamp { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public int BlogId { get; set; }
    }
}