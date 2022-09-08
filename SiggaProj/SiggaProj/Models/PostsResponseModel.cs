using SQLite;

namespace SiggaProj.Models
{
    [Table("tbPosts")]
    public class PostsResponseModel
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}
