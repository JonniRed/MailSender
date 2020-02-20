using MailSender.Infrastructure.Services.Interfaces;
using MailSender.lib.Entities;
using MailSender.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MailSender.Infrastructure.Services
{
    public class WindowSenderEditor : ISenderEditor
    {
        public void Edit(Sender sender)
        {
            var current_main_window = ((MainWindow)Application.Current.MainWindow);
            var editor = new SenderEditor(sender, current_main_window);
            editor.Owner = current_main_window;
            if (editor.ShowDialog() != true) return;
            sender.Name = editor.Name;
            sender.Adress = editor.AdressValue;
        }
    }
}
