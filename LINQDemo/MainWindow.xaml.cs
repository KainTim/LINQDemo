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

  PersonContext db = new();

  private void Window_Loaded(object sender, RoutedEventArgs e)
  {
    cboCountries.ItemsSource = db.Persons
      .DistinctBy(x => x.Adress.Country)
      .Select(x => x.Adress.Country).ToList();
    foreach (var item in panRadios.Children.OfType<RadioButton>())
    {
      item.Checked += RadioButton_Checked;
    }
    foreach (var item in panCheckboxes.Items.OfType<CheckBox>())
    {
      item.Checked += Checkbox_Checked_Changed;
      item.Unchecked += Checkbox_Checked_Changed;
    }
    foreach (var item in db.Persons.Select(x => x.Adress.City).Distinct())
    {
      var button = new Button()
      {
        Content = item,
      };
      button.Click += Button_Click
        ;
      panButtons.Children.Add(button);
    }
  }

  private void Button_Click(object sender, RoutedEventArgs e)
  {
    panPersons.Children.Clear();
    foreach (var item in db.Persons.Where(x => x.Adress.City.Equals(((Button)sender).Content)))
    {
      panPersons.Children.Add(new TextBox()
      {
        Text = item.ToString(),
      });
    }
  }

  private void Checkbox_Checked_Changed(object sender, RoutedEventArgs e)
  {
    lblCheckedCheckboxes.Content = string.Join(",", panCheckboxes.Items.OfType<CheckBox>()
      .Where(x => x.IsChecked ?? false)
      .Select(x => x.Content));
  }

  private void RadioButton_Checked(object sender, RoutedEventArgs e)
  {
    lblCheckedRadio.Content = ((RadioButton)sender).Content;
  }

  private void CboCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
  {
    lstPersonsInCountry.ItemsSource = db.Persons
      .Where(x => x.Adress.Country.Equals(cboCountries.SelectedItem))
      .OrderBy(x => x.Lastname)
      .ToList();
    lstPersonsInCountry.DisplayMemberPath = "";
  }

  private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
  {
    lstPersonsFound.ItemsSource = db.Persons
      .Where(x => x.Firstname.ToLower().Contains(txtSearch.Text.ToLower()) || x.Lastname.ToLower().Contains(txtSearch.Text.ToLower()))
      .ToList();
    lstPersonsFound.DisplayMemberPath = "SearchFormat";
    e.Handled = true;
  }

  private void SldMinLength_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
  {
    foreach (var item in panTextboxes.Children.OfType<TextBox>().Where(x => x.Text.Length < sldMinLength.Value))
    {
      item.Background = new SolidColorBrush(Colors.Red);
    }
    foreach (var item in panTextboxes.Children.OfType<TextBox>().Where(x => x.Text.Length >= sldMinLength.Value))
    {
      item.Background = new SolidColorBrush(Colors.White);
    }
  }


}
