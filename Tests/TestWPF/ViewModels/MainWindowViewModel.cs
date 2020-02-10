using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.MVVM;
namespace TestWPF.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "Наше новое окно";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
            //set
            //{
            //    if (Equals(_Title, value)) return;
              //  _Title = value;
               // OnPropertyChanged();
           // }
        }
        private string _TestValue = "90";
        public string TestValue
        {
            get => _TestValue;
            set => Set(ref _TestValue, value);
        }
        private double _X;
        private double _Y;
        public double X
        {
            get => _X;
            set => Set(ref _X, value);
        }
        public double Y
        {
            get => _X;
            set => Set(ref _X, value);
        }
    }
}
