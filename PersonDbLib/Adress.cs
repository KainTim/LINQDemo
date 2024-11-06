using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDbLib;
public class Adress
{
  public int Id { get; set; }
  public required string Country { get; set; }
  public required string City { get; set; }
  public int? PostalCode { get; set; }
  public required string StreetName { get; set; }
  public int StreetNumber { get; set; }
  public override string ToString() => $"{Country} {City} {StreetName} {StreetNumber}";
}
