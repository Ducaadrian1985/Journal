namespace Journal.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<JournalEntry>? JournalEntries { get; set; }
    }
    
}
