using PersonDbLib;

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LINQDemo;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
  public MainWindow() => InitializeComponent();

  private void Window_Loaded(object sender, RoutedEventArgs e)
  {
    var db = new PersonContext();
    lstNames.ItemsSource = db.Persons
      .Where(x => x.Gender == "Male")
      .Where(x => x.Birthdate.Year <= DateTime.Now.AddYears(-30).Year)
      .OrderBy(x => x.Lastname)
      .ThenBy(x => x.Firstname)
      .Select(x => $"{x.Lastname} {x.Birthdate}");
    grdNames.ItemsSource = db.Persons
      .Where(x=> x.Adress.Country=="Portugal");
  }
}
