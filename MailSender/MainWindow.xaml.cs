using System;
using System.Collections.Generic;
using System.Linq;
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
using MailSender.lib.Data;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //SenderList.ItemsSource = TestData.Senders;

        }

        private void Button_click_pl(object sender, RoutedEventArgs e)
        {
            test.SelectedItem = pl;
            pl.Visibility = Visibility;
        }

        private void Click_button_send(object sender, RoutedEventArgs e)
        {
            
            if (TextLetter.Text == "") MessageBox.Show("Введите текст");
        }
    }
}
