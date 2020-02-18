using System;
using System.Windows;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace TestWPF
{
    
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private async void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            const string message = "Hello me";
            var result = await GetMessageLengthAsync(message);
            Result.Text = result.ToString();
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {

        }
        private Task<int> GetMessageLengthAsync(string Message, int Timeout = 30)
        {
            return Task.Run(() => GetMessageLength(Message, Timeout));

        }
        private int _StartCount;
        private int GetMessageLength(string Message, int Timeout = 30)
        {
            for (var i = 0; i < 100; i++) Thread.Sleep(Timeout);
            return Message.Length + _StartCount++;
        }
    }
}
