using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDbLib;
public class PersonContext
{
  public List<Person> Persons { get; set; } = [];
  public List<Adress> Adresses { get; set; } = [];
  public PersonContext()
  {
    InitializePersons();
    InitializeAdresses();
  }

  private void InitializePersons()
  {
    //  0     1         2       3     4       5         6
    // id,firstname,lastname,email,gender,birthdate,adressId
    // 1,Dana,Shawley,dshawley0@nyu.edu,Male,27.08.1988,23
    // 2,Maddie,Greed,mgreed1@hexun.com,Female,07.10.1999,14

    Persons = File.ReadAllLines(@"csv\persons.csv")
      .Skip(1)
      .Select(x => x.Split(","))
      .Select(x => new Person()
      {
        Id = int.Parse(x[0]),
        Firstname = x[1],
        Lastname = x[2],
        Email = x[3],
        Gender = x[4],
        Birthdate = DateOnly.ParseExact(x[5], "dd.MM.yyyy"),
        AdressId = int.Parse(x[6]),
      }).ToList();
  }
  private void InitializeAdresses()
  {
    //  0    1      2        3        4            5
    // id,country,city,postalCode,streetName,streetNumber
    // 1,Portugal,Longos,4805-196,Briar Crest,7
    // 2,Cuba,Nueva Gerona,, Walton,7

    Adresses = File.ReadAllLines(@"csv\adresses.csv")
      .Skip(1)
      .Select(x => x.Split(","))
      .Select(x => new Adress()
      {
        Id = int.Parse(x[0]),
        Country = x[1],
        City = x[2],
        PostalCode = int.Parse(x[3]),
        StreetName = x[4],
        StreetNumber = int.Parse(x[5]),
      }).ToList();
  }
}
