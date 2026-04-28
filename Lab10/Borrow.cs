public class Borrow {
    public int Id { get; set; }
    public int ReaderId { get; set; }
    public int BookId { get; set; }
    public DateTime BorrowDate { get; set; }
    public Reader? Reader { get; set; }
    public Book? Book { get; set; }
}