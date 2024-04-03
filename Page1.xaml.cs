using PrPract4.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrPract4
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        EMPTableAdapter emp = new EMPTableAdapter();
        ConnectIdTableAdapter connect = new ConnectIdTableAdapter();
        public Page1()
        {
            InitializeComponent();
            tablic.ItemsSource = emp.GetData();
            Cb1.ItemsSource = emp.GetData();
            Cb1.DisplayMemberPath = "SURNAME";
        }
        private void poisc(object sender, RoutedEventArgs e)
        {
            tablic.ItemsSource = emp.SearchByName(text1.Text);
        }
        private void clearr(object sender, RoutedEventArgs e)
        {
            tablic.ItemsSource = emp.GetData();
        }

        private void Cb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cb1.SelectedItem != null)
            {
                var id = (int)(Cb1.SelectedItem as DataRowView).Row[0];
                tablic.ItemsSource = connect.FilterByEMP(id);
            }
        }
    }
}
