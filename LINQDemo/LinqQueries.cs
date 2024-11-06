using System.Runtime.CompilerServices;
using PersonDbLib;

namespace LinqCsvDemo;

public class LinqQueries(PersonContext db)
{
  public void ExecuteAll()
  {
    MalesStreetNrLessThan10();
    FirstnamesInChina();
    Console.WriteLine(MaxStreetNrInCountry("Poland"));
    CountriesWithEmailEndingWithOrg();
    PersonsFromIndonesia();
  }
  private static void LogMethodName(string msg = "", [CallerMemberName] string callerMethod = "") => Console.WriteLine($"--------------------- {callerMethod} {msg}");
  public List<string> MalesStreetNrLessThan10()
  {
    LogMethodName();
    return db.Persons
      .Where(x => x.Gender == "Male")
      .Where(x => x.Adress.StreetNumber < 10)
      .Select(x=> $"{x.Lastname} {x.Firstname}").ToList();
  }

  public List<string> FirstnamesInChina()
  {
    LogMethodName();
    return db.Persons
      .Where(x => x.Adress.Country == "China")
      .Select(x => x.Firstname)
      .Distinct()
      .ToList();
  }

  public int MaxStreetNrInCountry(string country)
  {
    LogMethodName(country);
    return db.Persons
      .Where(x => x.Adress.Country == country)
      .Max(x=> x.Adress.StreetNumber);
  }

  public List<string> CountriesWithEmailEndingWithOrg()
  {
    LogMethodName();
    return db.Persons
      .Where(x => x.Email.EndsWith("org"))
      .DistinctBy(x => x.Adress.Country)
      .Select(x => x.Adress.Country)
      .ToList();
  }

  public List<Person> PersonsFromIndonesia()
  {
    LogMethodName();
    var people = db.Persons
      .Where(x => x.Adress.Country.Equals("Indonesia"))
      .ToList();
    foreach (Person person in people)
    {
      Console.WriteLine(person.Adress.Country);
    }
    return db.Persons
      .Where(x => x.Adress.Country.Equals("Indonesia"))
      .ToList();
  }
}
