using System;

namespace API.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}