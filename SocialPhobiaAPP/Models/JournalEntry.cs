
using SQLite;

namespace SocialPhobiaAPP.Models
{
    public class JournalEntry
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
