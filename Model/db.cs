using System;
namespace TaskWebApiIntro
{
    public class CategoriesRequest
    {
        public string Name { get; set; }
        public string Description {get; set;}

    }

    public class Categories : CategoriesRequest
    {
        public int Id { get; set; }
    }

    public class MemberRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set;}
        public string FullName { get; set; }
        public string Popularity { get; set; }

    }

    public class Member : MemberRequest
    {
        public int Id { get; set; }
    }

    public class TopicRequest
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public int Member_id { get; set; }
    }

    public class Topic :TopicRequest
    {
        public int Id { get; set; }
          
    }

    public class RepliesRequest
    {
        public string Content { get; set; }
        public int Member_id { get; set; }
        public int Topic_id { get; set; }
    }
    public class Replies : RepliesRequest
    {
        public int Id { get; set; }

    }
}