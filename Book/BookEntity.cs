using System;

namespace Book.Domains
 {
    [Serializable]
    public class BookEntity:BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime AddDate { get; set; }
    }
}
