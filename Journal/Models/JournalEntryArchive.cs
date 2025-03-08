namespace Journal.Models;

public class JournalEntryArchive
{
    public int Id { get; set; }
    public int JournalEntryId { get; set; }
    public JournalEntry JournalEntry { get; set; }
}