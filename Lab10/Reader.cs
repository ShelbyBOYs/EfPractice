public class Reader {
  public int Id { get; set; }
  public string Name { get; set; } = "";

  public List<Borrow> Borrows { get; set; } = new();

}