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

  }

  private void CboCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
  {
  }

  private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
  {
  }

  private void SldMinLength_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
  {
  }


}
