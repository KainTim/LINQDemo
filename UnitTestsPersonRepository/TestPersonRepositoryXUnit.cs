using FluentAssertions;


using LinqCsvDemo;

using PersonDbLib;

namespace UnitTestsPersonRepository;

//FluentAssertions required - so don't forget to install: dotnet add package FluentAssertions

public class TestPersonRepositoryXUnit
{
  private readonly PersonContext _db;
  private readonly LinqQueries _linqDemo;
  public TestPersonRepositoryXUnit()
  {
    _db = new PersonContext();
    _linqDemo = new LinqQueries(_db);
  }

  [Fact]
  public void T01_TestMalesStreetNrLessThan10()
  {
    var expected = new List<string> { "Ixor Derrik", "Skellen Donall", "Wightman Romain" };
    var actual = _linqDemo.MalesStreetNrLessThan10();
    actual.Should().BeEquivalentTo(expected);
  }

  [Fact]
  public void T02_TestFirstnamesInChina()
  {
    var expected = new List<string> { "Brier", "Caro", "Elonore", "Fletch", "Jeffrey", "Leda", "Leroy", "Lolly", "Lynette", "Noe", "Olly", "Pamelina", "Roley", "Salem", "Shantee", "Terra", "Tess" };
    var actual = _linqDemo.FirstnamesInChina();
    actual.Select(x => x.ToString()).Should().BeEquivalentTo(expected);
  }

  [Theory]
  [InlineData("Poland", 881)]
  [InlineData("Mexico", 5747)]
  [InlineData("United States", 9287)]
  public void T03_TestMaxStreetNrInCountry(string country, int expected)
  {
    int actual = _linqDemo.MaxStreetNrInCountry(country);
    Assert.Equal(expected, actual);
  }

  [Fact]
  public void T04_TestCountriesWithEmailEndingWithOrg()
  {
    var expected = new List<string> { "China", "Egypt", "Indonesia", "Poland", "Russia" };
    var actual = _linqDemo.CountriesWithEmailEndingWithOrg();
    actual.Should().BeEquivalentTo(expected);
  }

  [Fact]
  public void T05_TestPersonsFromIndonesia()
  {
    var expected = new List<string> { "Lippo Royce", "Mower Shelden", "Piola Electra", "Rawe Sarene" };
    var actual = _linqDemo.PersonsFromIndonesia();
    actual.Select(x => $"{x.Lastname} {x.Firstname}").Should().BeEquivalentTo(expected);
  }
}
