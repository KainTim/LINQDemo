namespace PersonDbLib;

public class Person
{
  public int Id { get; set; }
  public required string Firstname { get; set; }
  public required string Lastname { get; set; }
  public required string Email { get; set; }
  public required string Gender { get; set; }
  public DateOnly Birthdate { get; set; }
  public int AdressId { get; set; }
  public Adress Adress { get; set; } = null!;
  public override string ToString() => $"{Lastname} {Firstname} {Gender} {Birthdate:yyyy}";
}
