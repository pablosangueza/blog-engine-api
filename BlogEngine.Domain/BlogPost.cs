using System.Collections;
using System;
using System.Collections.Generic;

namespace BlogEngine.Domain
{
    public enum PostStatus
    {
        Pending = 0,
        Approved = 1,
        Editing = 3

    }
    public class BlogPost
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public User Author { get; set; }
        public PostStatus Status { get; set; }
        public IList<string> Comments {get; set;}

    }
}