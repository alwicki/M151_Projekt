using System;

namespace API.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int UserId {get; set;}
        public string UserName {get; set; }
        public int RecipeId {get; set;}
    }
}